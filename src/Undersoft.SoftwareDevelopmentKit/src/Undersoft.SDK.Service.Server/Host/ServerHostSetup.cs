using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;

namespace Undersoft.SDK.Service.Server;

using Logging;
using Microsoft.AspNetCore.Routing;
using Series;

public class ServerHostSetup : IServerHostSetup
{
    public static bool defaultProvider;

    IApplicationBuilder app;
    IWebHostEnvironment env;
    IEndpointRouteBuilder erb;

    public ServerHostSetup(IApplicationBuilder application) { app = application; }

    public ServerHostSetup(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        app = application;
        env = environment;
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
        app.UseEndpoints(endpoints =>
        {
            var method = typeof(GrpcEndpointRouteBuilderExtensions).GetMethods().Where(m => m.Name.Contains("MapGrpcService")).FirstOrDefault().GetGenericMethodDefinition();
            ISeries<Type> serviceContracts = GrpcDataServerRegistry.ServiceContracts;
            if (serviceContracts.Any())
            {
                foreach (var serviceContract in serviceContracts)
                    method.MakeGenericMethod(serviceContract).Invoke(endpoints, new object[] { endpoints });

                endpoints.MapCodeFirstGrpcReflectionService();
            }

            ServiceManager
               .GetRegistry()
                   .MergeServices();

            endpoints.MapControllers();

            if (useRazorPages)
                endpoints.MapRazorPages();

            endpoints.MapFallbackToFile("/index.html");
        });

        return this;
    }

    public IServerHostSetup MapFallbackToFile(string filePath)
    {
        app.UseEndpoints(endpoints =>
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
        using (IServiceScope scope = ServiceManager.GetRootProvider().CreateScope())
        {
            try
            {
                IServicer us = scope.ServiceProvider.GetRequiredService<IServicer>();
                us.GetSources().ForEach(e => ((DbContext)e.Context).Database.Migrate());
            }
            catch (Exception ex)
            {
                this.Error<Applog>("DataServer migration initial create - unable to connect the database engine", null, ex);
            }
        }

        return this;
    }

    public IServerHostSetup UseDefaultProvider()
    {
        ServiceManager.GetRegistry().MergeServices(false);
        ServiceManager.SetProvider(app.ApplicationServices);
        defaultProvider = true;
        return this;
    }

    public IServerHostSetup UseInternalProvider()
    {
        ServiceManager.GetRegistry().MergeServices();
        app.ApplicationServices = ServiceManager.BuildInternalProvider();
        return this;
    }

    public IServerHostSetup UseApiSetup(string[] apiVersions = null)
    {
        UseHeaderForwarding();

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseODataBatching();
        app.UseODataQueryRequest();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors();

        if (apiVersions != null)
            UseSwaggerSetup(apiVersions);

        app.UseAuthentication();
        app.UseAuthorization();

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
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        var ao = ServiceManager.GetConfiguration().Identity;

        app.UseSwagger();
        app.UseSwaggerUI(
            s =>
            {
                s.SwaggerEndpoint($"{ao.ApiBaseUrl}/swagger/v1/swagger.json", ao.ApiName);
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

        app.UseForwardedHeaders(forwardingOptions);

        return this;
    }

    public IServerHostSetup UseJwtMiddleware()
    {
        app.UseMiddleware<ServerHostJwtMiddleware>();

        return this;
    }

    public IApplicationBuilder Application => app;
}