using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Data.Repository;

namespace Undersoft.SDK.Service.Host
{
    public static class ServiceHostSetupExtensions
    {
        public static IServiceHostSetup UseAppSetup(this IHostBuilder app, IHostingEnvironment env)
        {
            return new ServiceHostSetup(app, env);
        }

        public static IHostBuilder UseInternalProvider(this IHostBuilder app)
        {
            new ServiceHostSetup(app).UseInternalProvider();
            return app;
        }

        public static IHostBuilder RebuildProviders(this IHostBuilder app)
        {
            new ServiceHostSetup(app).RebuildProviders();
            return app;
        }

        public static async Task LoadOpenDataEdms(this IServiceHostSetup app)
        {
            await Task.Run(() =>
            {
                RepositoryManager.Clients.ForEach((client) =>
                {
                    client.BuildMetadata();
                });

                ServiceHostSetup.AddOpenDataServiceImplementations();
                app.RebuildProviders();
            });
        }

    }
}