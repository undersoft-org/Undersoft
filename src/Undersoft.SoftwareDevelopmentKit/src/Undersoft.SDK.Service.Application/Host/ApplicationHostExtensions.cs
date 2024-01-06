using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Undersoft.SDK.Service.Application;

using Undersoft.SDK.Service.Data.Repository;
using Service.Host;

public static class ApplicationHostExtensions
{
    public static IApplicationHostSetup UseApplicationSetup(this IApplicationBuilder app)
    {
        return new ApplicationHostSetup(app);
    }
    public static IApplicationHostSetup UseApplicationSetup(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return new ApplicationHostSetup(app, env);
    }
    public static IApplicationBuilder UseDefaultProvider(this IApplicationBuilder app)
    {
        new ApplicationHostSetup(app).UseDefaultProvider();
        return app;
    }

    public static IApplicationBuilder UseInternalProvider(this IApplicationBuilder app)
    {
        new ApplicationHostSetup(app).UseInternalProvider();
        return app;
    }

    public static IApplicationBuilder RebuildProviders(this IApplicationBuilder app)
    {
        new ApplicationHostSetup(app).RebuildProviders();
        return app;
    }

    public static async Task LoadOpenDataEdms(this ApplicationHostSetup app)
    {
        await Task.Run(() =>
        {
            Task.WaitAll(RepositoryManager.Clients.ForEach((client) =>
            {
               return client.BuildMetadata();
            }).Commit());

            ServiceHostSetup.AddOpenDataServiceImplementations();
            app.RebuildProviders();
        });
    }
}