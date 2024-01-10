using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            var setup = services.AddServerSetup(services.AddControllers());
            setup
                .ConfigureServer(
                    true,
                    AppDomain.CurrentDomain.GetAssemblies(),
                    new[]
                    {
                        typeof(ServiceEntryStore),
                        typeof(ServiceReportStore),
                        typeof(ServiceIdentityStore),
                        typeof(ServiceEventStore)
                    }
                )
                .AddAccountIdentity<ServiceIdentityStore>()
                .AddDataServer<IDataServiceStore>(
                    DataServerTypes.All,
                    builder => builder.AddAuthorizationService()
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseServerSetup(env)
                .UseApiSetup(new string[] { "v1.0" })
                .UseInternalProvider()
                .UseDataMigrations();
        }
    }
}
