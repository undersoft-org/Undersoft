using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.Hosting;

using Logging;
using Microsoft.AspNetCore.Routing;
using Series;

public class ServerHostSetup : IServerHostSetup
{
    public static bool defaultProvider;

    IApplicationBuilder _application;
    IWebHostEnvironment _environment;
    IEndpointRouteBuilder _routeBuilder;
    IServiceManager _serviceManager;

    public ServerHostSetup(IApplicationBuilder application)
    {
        _application = application;
        _serviceManager = _application.ApplicationServices.GetService<IServiceManager>();
    }

    public ServerHostSetup(IApplicationBuilder application, IWebHostEnvironment environment)
        : this(application)
    {
        _environment = environment;
    }

    public IServerHostSetup RebuildProviders()
    {
        if (defaultProvider)
        {
            UseDefaultProvider();
        }
        else
        {
            UseInternalProvider();
        }

        return this;
    }

    public IServerHostSetup UseEndpoints(bool useRazorPages = false)
    {
        _application.UseEndpoints(endpoints =>
        {
            var method = typeof(GrpcEndpointRouteBuilderExtensions)
                .GetMethods()
                .Where(m => m.Name.Contains("MapGrpcService"))
                .FirstOrDefault()
                .GetGenericMethodDefinition();

            ISeries<Type> serviceContracts = GrpcDataServerRegistry.ServiceContracts;

            if (serviceContracts.Any())
            {
                foreach (var serviceContract in serviceContracts)
                    method
                        .MakeGenericMethod(serviceContract)
                        .Invoke(endpoints, new object[] { endpoints });

                endpoints.MapCodeFirstGrpcReflectionService();
            }

            _serviceManager.Registry.MergeServices();

            endpoints.MapControllers();

            if (useRazorPages)
            {
                endpoints.MapRazorPages();
                endpoints.MapFallbackToFile("/index.html");
            }
        });

        return this;
    }

    public IServerHostSetup MapFallbackToFile(string filePath)
    {
        _application.UseEndpoints(endpoints =>
        {
            endpoints.MapFallbackToFile(filePath);
        });

        return this;
    }

    public IServerHostSetup UseDataServices()
    {
        this.LoadOpenDataEdms().ConfigureAwait(true);
        return this;
    }

    public IServerHostSetup UseDataMigrations()
    {
        using (IServiceScope scope = _serviceManager.CreateScope())
        {
            try
            {
                IServicer us = scope.ServiceProvider.GetRequiredService<IServicer>();
                us.GetSources().ForEach(e => ((DbContext)e.Context).Database.Migrate());
            }
            catch (Exception ex)
            {
                this.Error<Applog>(
                    "DataServer migration initial create - unable to connect the database engine",
                    null,
                    ex
                );
            }
        }

        return this;
    }

    public IServerHostSetup UseDefaultProvider()
    {
        _serviceManager.Registry.MergeServices(false);
        ServiceManager.SetProvider(_application.ApplicationServices);
        defaultProvider = true;
        return this;
    }

    public IServerHostSetup UseInternalProvider()
    {
        _serviceManager.Registry.MergeServices(true);
        _application.ApplicationServices = _serviceManager.BuildInternalProvider();
        return this;
    }

    public IServerHostSetup UseApiServerSetup(string[] apiVersions = null)
    {
        UseHeaderForwarding();

        if (_environment.IsDevelopment())
            _application
                .UseDeveloperExceptionPage();

        _application
            .UseHttpsRedirection()
            .UseODataBatching()
            .UseODataQueryRequest()
            .UseDefaultFiles()
            .UseStaticFiles()
            .UseRouting()
            .UseCors();

        if (apiVersions != null)
            UseSwaggerSetup(apiVersions);

        _application
            .UseAuthentication()
            .UseAuthorization();

        UseJwtMiddleware();

        UseEndpoints();

        return this;
    }

    public IServerHostSetup UseCustomSetup(Action<IServerHostSetup> action)
    {
        action(this);

        return this;
    }

    public IServerHostSetup UseSwaggerSetup(string[] apiVersions)
    {
        if (_application == null)
        {
            throw new ArgumentNullException(nameof(_application));
        }

        var ao = _serviceManager.GetConfiguration().Identity;

        _application
            .UseSwagger()
            .UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"{ao.ServiceBaseUrl}/swagger/v1/swagger.json", ao.ServiceName);
                //s.OAuthClientId(ao.SwaggerClientId);
                //s.OAuthAppName(ao.ApiName);
            });
        return this;
    }

    public IServerHostSetup UseHeaderForwarding()
    {
        var forwardingOptions = new ForwardedHeadersOptions()
        {
            ForwardedHeaders = ForwardedHeaders.All
        };

        forwardingOptions.KnownNetworks.Clear();
        forwardingOptions.KnownProxies.Clear();

        _application.UseForwardedHeaders(forwardingOptions);

        return this;
    }

    public IServerHostSetup UseJwtMiddleware()
    {
        _application.UseMiddleware<ServerHostJwtMiddleware>();

        return this;
    }

    public IApplicationBuilder Application => _application;

    public IServiceManager Manager => _serviceManager;
}
