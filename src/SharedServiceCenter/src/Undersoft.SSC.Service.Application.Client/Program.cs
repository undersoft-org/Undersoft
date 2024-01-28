using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Runtime.Intrinsics.X86;
using Undersoft.SDK.Service;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Application.UI.Shared;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var manager = builder.Services
                .AddServiceSetup(builder.Configuration)
                .ConfigureServices(null, new[] { typeof(ApplicationClient), typeof(AccessClient) })
                .Manager;

            var _provider = await manager.BuildInternalProvider().UseServiceClients();

            builder.ConfigureContainer(
                manager.GetProviderFactory(),
                (services) =>
                {
                    var reg = manager.GetRegistry();
                    reg.Services = services;
                    reg.AddAuthorizationCore();
                    reg.AddScoped<AccessProvider<Account>>();
                    reg.AddScoped<AuthenticationStateProvider, AccessProvider<Account>>(
                        provider => provider.GetRequiredService<AccessProvider<Account>>()
                    );
                    reg.AddScoped<IAccessService, AccessProvider<Account>>(
                        provider => provider.GetRequiredService<AccessProvider<Account>>()
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
