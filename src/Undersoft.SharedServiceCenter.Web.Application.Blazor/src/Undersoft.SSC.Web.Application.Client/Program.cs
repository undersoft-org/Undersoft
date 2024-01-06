using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Undersoft.SDK.Blazor.Services;
using Undersoft.SDK.Service;
using Undersoft.SSC.Web.Infrastructure.Persistance.Services;

namespace Undersoft.SSC.Web.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var serviceSetup = builder.Services.AddServiceSetup(builder.Configuration);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.ConfigureContainer(
                ServiceManager.GetProviderFactory(),
                async (services) =>
                {
                    services.AddAuthorizationCore();
                    serviceSetup.ConfigureServices(
                        AppDomain.CurrentDomain.GetAssemblies(),
                        null,
                        new[] { typeof(OpenDataService) }
                    );
                    var reg = ServiceManager.GetRegistry();
                    reg.MergeServices(services, true);
                    services.AddScoped<JWTAuthenticationStateProvider>();
                    services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                        );
                    await ServiceManager.BuildInternalProvider().UseDataServices();
                    reg.MergeServices(services, true);
                }
            );

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            await host.RunAsync();
        }
    }
}
