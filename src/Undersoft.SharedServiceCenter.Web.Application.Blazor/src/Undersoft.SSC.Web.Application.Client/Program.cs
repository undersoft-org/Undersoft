using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services
                .AddServiceSetup(builder.Configuration)
                .ConfigureServices(
                    AppDomain.CurrentDomain.GetAssemblies(),
                    null,
                    new[] { typeof(OpenDataService) }
                );

            var provider = await ServiceManager.BuildInternalProvider().UseDataServices();

            builder.ConfigureContainer(
                ServiceManager.GetProviderFactory(),
                (services) =>
                {
                    var reg = ServiceManager.GetRegistry();
                    reg.Services = services;
                    reg.AddAuthorizationCore();
                    reg.AddScoped<JWTAuthenticationStateProvider>();
                    reg.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                    );
                    reg.AddScoped<IAuthenticationStateService, JWTAuthenticationStateProvider>(
                       provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                   );
                    reg.MergeServices(true);
                }
            );

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            await host.RunAsync();
        }
    }
}
