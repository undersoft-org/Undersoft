using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service;

using Configuration;
using Data.Cache;
using Data.Mapper;
using Infrastructure.Repository;
using Infrastructure.Repository.Client;
using Infrastructure.Repository.Source;
using Infrastructure.Store;
using Security.Identity;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Client;

public partial class ServiceSetup : IServiceSetup
{
    protected string[] apiVersions = new string[1] { "1" };
    protected Assembly[] Assemblies;

    protected IServiceConfiguration configuration => manager.Configuration;
    protected IServiceManager manager { get; }
    protected IServiceRegistry registry => manager.Registry;
    protected IServiceCollection services => registry.Services;

    public ServiceSetup(IServiceCollection services)
    {
        manager = new ServiceManager(services);
        registry.MergeServices(true);
    }

    public ServiceSetup(IServiceCollection services, IConfiguration configuration) : this(services)
    {
        manager.Configuration = new ServiceConfiguration(configuration, services);
    }

    public IServiceRegistry Services => registry;

    public IServiceManager Manager => manager;

    public IServiceSetup AddCaching()
    {
        registry.AddObject(RootCache.Catalog);

        Type[] stores = new Type[]
        {
            typeof(IEntryStore),
            typeof(IReportStore),
            typeof(IEventStore),
            typeof(IDataStore),
            typeof(IAccountStore)
        };
        foreach (Type item in stores)
        {
            AddStoreCache(item);
        }

        return this;
    }

    public virtual IServiceSetup AddSourceProviderConfiguration()
    {
        ServiceManager.AddRootObject<ISourceProviderConfiguration>(new ServiceSourceProviderConfiguration(registry));

        return this;
    }

    public void AddJsonSerializerDefaults()
    {
#if NET6_0
        var newopts = new JsonSerializerOptions();
        newopts.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        newopts.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        newopts.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        newopts.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        var fld = (
            typeof(JsonSerializerOptions).GetField(
                "s_defaultOptions",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic
            )
        );

        var opt = (JsonSerializerOptions)fld.GetValue(newopts);
        if (opt == null)
            fld.SetValue(newopts, newopts);
        else
            manager.Mapper.Map(newopts, opt);
#endif
#if NET7_0
        var flds = typeof(JsonSerializerOptions).GetRuntimeFields();
        flds.Single(f => f.Name == "_defaultIgnoreCondition")
            .SetValue(JsonSerializerOptions.Default, JsonIgnoreCondition.WhenWritingNull);
        flds.Single(f => f.Name == "_referenceHandler")
            .SetValue(JsonSerializerOptions.Default, ReferenceHandler.IgnoreCycles);
#endif
    }

    public IServiceSetup AddLogging()
    {
        registry.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        return this;
    }

    public IServiceSetup AddOpenTelemetry()
    {
        var config = configuration;

        Action<ResourceBuilder> configureResource = r =>
            r.AddService(
                serviceName: config.GetValue<string>("ServiceName"),
                serviceVersion: Environment.Version.ToString(),
                serviceInstanceId: Environment.MachineName
            );

        var tracingExporter = config.GetValue<string>("UseTracingExporter").ToLowerInvariant();
        var histogramAggregation = config
            .GetValue<string>("HistogramAggregation")
            .ToLowerInvariant();
        var metricsExporter = config.GetValue<string>("UseMetricsExporter").ToLowerInvariant();

        registry.AddSingleton<Instrumentation>();

        services
            .AddOpenTelemetry()
            .ConfigureResource(configureResource)
            .WithTracing(builder =>
            {
                switch (tracingExporter)
                {
                    case "jaeger":
                        builder.AddJaegerExporter();

                        builder.ConfigureServices(services =>
                        {
                            // Use IConfiguration binding for Jaeger exporter options.
                            services.Configure<JaegerExporterOptions>(config.GetSection("Jaeger"));

                            // Customize the HttpClient that will be used when JaegerExporter is configured for HTTP transport.
                            services.AddHttpClient(
                                "JaegerExporter",
                                configureClient: (client) =>
                                    client.DefaultRequestHeaders.Add(
                                        "X-Title",
                                        config.Title
                                            + " ,OS="
                                            + Environment.OSVersion
                                            + ",ServiceName="
                                            + Environment.MachineName
                                            + ",Domain="
                                            + Environment.UserDomainName
                                    )
                            );
                        });
                        break;

                    case "zipkin":
                        builder.AddZipkinExporter();

                        builder.ConfigureServices(services =>
                        {
                            // Use IConfiguration binding for Zipkin exporter options.
                            services.Configure<ZipkinExporterOptions>(config.GetSection("Zipkin"));
                        });
                        break;

                    case "otlp":
                        builder.AddOtlpExporter(otlpOptions =>
                        {
                            // Use IConfiguration directly for Otlp exporter source option.
                            otlpOptions.Endpoint = new Uri(config.GetValue<string>("Otlp:Source"));
                        });
                        break;

                    default:
                        builder.AddConsoleExporter();
                        break;
                }
            })
            .WithMetrics(builder =>
            {
                // Metrics

                // Ensure the MeterProvider subscribes to any custom Meters.
                builder.AddRuntimeInstrumentation().AddHttpClientInstrumentation();
                //.AddAspNetCoreInstrumentation();

                switch (histogramAggregation)
                {
                    case "exponential":
                        builder.AddView(instrument =>
                        {
                            return
                                instrument.GetType().GetGenericTypeDefinition()
                                == typeof(Histogram<>)
                                ? new ExplicitBucketHistogramConfiguration()
                                : null;
                        });
                        break;
                    default:
                        // Explicit bounds histogram is the default.
                        // No additional configuration necessary.
                        break;
                }

                switch (metricsExporter)
                {
                    case "otlp":
                        builder.AddOtlpExporter(otlpOptions =>
                        {
                            // Use IConfiguration directly for Otlp exporter source option.
                            otlpOptions.Endpoint = new Uri(config.GetValue<string>("Otlp:Source"));
                        });
                        break;
                    default:
                        builder.AddConsoleExporter();
                        break;
                }
            });

        return this;
    }

    public IServiceSetup AddPropertyInjection()
    {
        manager.AddPropertyInjection();

        return this;
    }

    public IServiceSetup AddImplementations()
    {
        registry.AddScoped<IServicer, Servicer>();
        registry.AddScoped<IAuthorization, Account>();

        AddDomainImplementations();

        registry.MergeServices(true);

        return this;
    }

    public IServiceSetup AddMapper<TProfile>() where TProfile : MapperProfile
    {
        AddMapper(new DataMapper(typeof(TProfile).New<TProfile>()));

        return this;
    }

    public IServiceSetup AddMapper(params MapperProfile[] profiles)
    {
        AddMapper(new DataMapper(profiles));

        return this;
    }

    public IServiceSetup AddMapper(IDataMapper mapper)
    {
        registry.AddObject(mapper);
        registry.AddObject<IDataMapper>(mapper);
        registry.AddScoped<IMapper, DataMapper>();

        return this;
    }

    public IServiceSetup AddRepositoryClients()
    {        
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        Type[] serviceTypes = assemblies.SelectMany(a => a.DefinedTypes).Select(t => t.UnderlyingSystemType).ToArray();
        return AddRepositoryClients(serviceTypes);
    }

    public IServiceSetup AddRepositoryClients(Type[] serviceTypes)
    {
        IServiceConfiguration config = configuration;

        IEnumerable<IConfigurationSection> clients = config.Clients();
        RepositoryClients repoClients = new RepositoryClients();

        services.AddSingleton(registry.AddObject<IRepositoryClients>(repoClients).Value);

        foreach (IConfigurationSection client in clients)
        {
            ClientProvider provider = config.ClientProvider(client);
            string connectionString = config.ClientConnectionString(client).Trim();
            int poolsize = config.ClientPoolSize(client);
            Type contextType = serviceTypes
                .Where(t => t.FullName.Contains(client.Key))                
                .FirstOrDefault();

            if (
                (provider == ClientProvider.None)
                || (connectionString == null)
                || (contextType == null)
            )
                continue;

            string routePrefix = AddDataClientPrefix(contextType).Trim();
            if (!connectionString.EndsWith('/'))
                connectionString += "/";

            if (routePrefix.StartsWith('/'))
                routePrefix = routePrefix.Substring(1);

            routePrefix = provider.ToString().ToLower() + "/" + routePrefix;

            if (routePrefix.EndsWith('/'))
                routePrefix = routePrefix.Substring(1);

            string _connectionString = $"{connectionString}{routePrefix}";

            Type iRepoType = typeof(IRepositoryClient<>).MakeGenericType(contextType);
            Type repoType = typeof(RepositoryClient<>).MakeGenericType(contextType);

            IRepositoryClient repoClient = (IRepositoryClient)
                repoType.New(provider, _connectionString);

            Type storeDbType = typeof(OpenDataClient<>).MakeGenericType(
                OpenDataRegistry.GetLinkedStoreTypes(contextType)
            );
            Type storeRepoType = typeof(RepositoryClient<>).MakeGenericType(storeDbType);

            IRepositoryClient storeClient = (IRepositoryClient)storeRepoType.New(repoClient);

            Type istoreRepoType = typeof(IRepositoryClient<>).MakeGenericType(storeDbType);
            Type ipoolRepoType = typeof(IRepositoryContextPool<>).MakeGenericType(storeDbType);
            Type ifactoryRepoType = typeof(IRepositoryContextFactory<>).MakeGenericType(
                storeDbType
            );
            Type idataRepoType = typeof(IRepositoryContext<>).MakeGenericType(storeDbType);

            repoClient.PoolSize = poolsize;

            IRepositoryClient globalClient = manager.AddClient(repoClient);

            registry.AddObject(iRepoType, globalClient);
            registry.AddObject(repoType, globalClient);

            registry.AddObject(istoreRepoType, storeClient);
            registry.AddObject(ipoolRepoType, storeClient);
            registry.AddObject(ifactoryRepoType, storeClient);
            registry.AddObject(idataRepoType, storeClient);
            registry.AddObject(storeRepoType, storeClient);

            manager.AddClientPool(globalClient.ContextType, poolsize);
        }

        return this;
    }

    public IServiceSetup AddRepositorySources()
    {
       var assemblies  = Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        Type[] storeTypes = assemblies.SelectMany(a => a.DefinedTypes).Select(t => t.UnderlyingSystemType).ToArray();
        return AddRepositorySources(storeTypes);
    }

    public IServiceSetup AddRepositorySources(Type[] storeTypes)
    {
        IServiceConfiguration config = configuration;
        IEnumerable<IConfigurationSection> sources = config.Sources();

        RepositorySources repoSources = new RepositorySources();
        registry.AddSingleton(registry.AddObject<IRepositorySources>(repoSources).Value);

        var providerNotExists = new HashSet<string>();

        foreach (IConfigurationSection source in sources)
        {
            string connectionString = config.SourceConnectionString(source);
            SourceProvider provider = config.SourceProvider(source);
            int poolsize = config.SourcePoolSize(source);
            Type contextType = storeTypes
                .Where(t => t.FullName == source.Key)
                .FirstOrDefault();

            if (
                (provider == SourceProvider.None)
                || (connectionString == null)
                || (contextType == null)
            )
            {
                continue;
            }

            if (providerNotExists.Add(provider.ToString()))
            {
                registry.AddEntityFrameworkSourceProvider(provider);
                registry.MergeServices(true);
            }
     
            Type iRepoType = typeof(IRepositorySource<>).MakeGenericType(contextType);
            Type repoType = typeof(RepositorySource<>).MakeGenericType(contextType);
            Type repoOptionsType = typeof(DbContextOptions<>).MakeGenericType(contextType);
            Type repoOptionsBuilderType = typeof(DbContextOptionsBuilder<>).MakeGenericType(contextType);

            var builder = registry.GetObject<ISourceProviderConfiguration>();
            var options = builder.BuildOptions(repoOptionsBuilderType.New<DbContextOptionsBuilder>(), provider, connectionString).Options;

            IRepositorySource repoSource = (IRepositorySource)
                repoType.New(options);

            Type storeDbType = typeof(DataStoreContext<>).MakeGenericType(
                DataStoreRegistry.GetStoreType(contextType)
            );
            Type storeOptionsType = typeof(DbContextOptions<>).MakeGenericType(storeDbType);
            Type storeRepoType = typeof(RepositorySource<>).MakeGenericType(storeDbType);

            IRepositorySource storeSource = (IRepositorySource)storeRepoType.New(repoSource);

            Type istoreRepoType = typeof(IRepositorySource<>).MakeGenericType(storeDbType);
            Type ipoolRepoType = typeof(IRepositoryContextPool<>).MakeGenericType(storeDbType);
            Type ifactoryRepoType = typeof(IRepositoryContextFactory<>).MakeGenericType(
                storeDbType
            );
            Type idataRepoType = typeof(IRepositoryContext<>).MakeGenericType(storeDbType);

            repoSource.PoolSize = poolsize;

            IRepositorySource globalSource = manager.AddSource(repoSource);

            AddDatabaseConfiguration(globalSource.Context);

            registry.AddObject(contextType, globalSource.Context);

            registry.AddObject(iRepoType, globalSource);
            registry.AddObject(repoType, globalSource);
            registry.AddObject(repoOptionsType, globalSource.Options);

            registry.AddObject(istoreRepoType, storeSource);
            registry.AddObject(ipoolRepoType, storeSource);
            registry.AddObject(ifactoryRepoType, storeSource);
            registry.AddObject(idataRepoType, storeSource);
            registry.AddObject(storeRepoType, storeSource);
            registry.AddObject(storeOptionsType, storeSource.Options);

            manager.AddSourcePool(globalSource.ContextType, poolsize);
        }

        return this;
    }

    public virtual IServiceSetup ConfigureServices(Type[] sourceTypes = null, Type[] clientTypes = null)
    {
        Assemblies = AppDomain.CurrentDomain.GetAssemblies();

        AddLogging();

        AddMapper(new DataMapper());        

        AddJsonSerializerDefaults();

        AddSourceProviderConfiguration();

        if(sourceTypes != null)
            AddRepositorySources(sourceTypes);
        else
            AddRepositorySources();

        if(clientTypes != null)
            AddRepositoryClients(clientTypes);
        else
            AddRepositoryClients();   

        AddImplementations();

        AddCaching();

        return this;
    }

    public IServiceSetup MergeServices()
    {
        registry.MergeServices();

        return this;
    }

    public IServiceSetup AddStoreCache(Type tstore)
    {
        Type idatacache = typeof(IStoreCache<>).MakeGenericType(tstore);
        Type datacache = typeof(StoreCache<>).MakeGenericType(tstore);

        object cache = datacache.New(registry.GetObject<IDataCache>());

        registry.AddObject(idatacache, cache);
        registry.AddObject(datacache, cache);

        return this;
    }

    public IServiceSetup AddStoreCache<TStore>()
    {
        return AddStoreCache(typeof(TStore));
    }

    private void AddDatabaseConfiguration(IDataStoreContext context)
    {
        DbContext _context = context as DbContext;
        _context.ChangeTracker.AutoDetectChangesEnabled = true;
        _context.ChangeTracker.LazyLoadingEnabled = true;
        _context.Database.AutoTransactionsEnabled = false;
    }

    private string AddDataClientPrefix(Type contextType, string routePrefix = null)
    {
        Type iface = OpenDataRegistry.GetLinkedStoreTypes(contextType);
        return GetStoreRoutes(iface, routePrefix);
    }

    private string AddDataServiceStorePrefix(Type contextType, string routePrefix = null)
    {
        Type iface = DataStoreRegistry.GetStoreType(contextType);
        return GetStoreRoutes(iface, routePrefix);
    }

    private string GetStoreRoutes(Type iface, string routePrefix = null)
    {
        if (iface == typeof(IEntryStore))
        {
            return StoreRoutes.EntryStoreRoute;
        }
        else if (iface == typeof(IEventStore))
        {
            return StoreRoutes.EventStoreRoute;
        }
        else if (iface == typeof(IReportStore))
        {
            return StoreRoutes.ReportStoreRoute;
        }
        else if (iface == typeof(IDataStore))
        {
            return StoreRoutes.DataStoreRoute;
        }
        else if (iface == typeof(IAccountStore))
        {
            return StoreRoutes.AuthStoreRoute;
        }
        else
        {
            return StoreRoutes.DataStoreRoute;
        }
    }
}
