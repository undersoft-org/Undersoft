using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Undersoft.SDK.Service.Application.Services;
using Undersoft.SSC.Service.Application.UI;
using Undersoft.SDK.Service;
using Undersoft.SSC.Service.Clients;

namespace Undersoft.SSC.Service.Application.Client
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
                    reg.AddScoped<MemberAuthenticationStateProvider>();
                    reg.AddScoped<AuthenticationStateProvider, MemberAuthenticationStateProvider>(
                        provider => provider.GetRequiredService<MemberAuthenticationStateProvider>()
                    );
                    reg.AddScoped<IAuthenticationStateService, MemberAuthenticationStateProvider>(
                       provider => provider.GetRequiredService<MemberAuthenticationStateProvider>()
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
