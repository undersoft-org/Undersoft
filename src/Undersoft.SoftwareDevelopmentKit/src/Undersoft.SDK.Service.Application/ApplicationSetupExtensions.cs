using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service.Host;

namespace Undersoft.SDK.Service.Application
{
    public static class ApplicationSetupExtensions
    {
        public static IApplicationSetup AddApplicationSetup(this IServiceCollection services, IMvcBuilder mvcBuilder = null)
        {
            return new ApplicationSetup(services, mvcBuilder);
        }

        public static async Task LoadOpenDataEdms(this ApplicationSetup app)
        {
            await Task.Run(() =>
            {
                RepositoryManager.Clients.ForEach((client) =>
                {
                    client.BuildMetadata();
                });

                ServiceHostSetup.AddOpenDataServiceImplementations();
            });
        }
    }
}
