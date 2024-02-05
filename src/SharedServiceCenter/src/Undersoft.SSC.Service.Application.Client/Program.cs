using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SSC.Service.Clients;
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
                .ConfigureServices(
                new[]
                {
                    typeof(ApplicationClient),
                    typeof(AccessClient)
                })
                .Manager;

            await manager.BuildInternalProvider().UseServiceClients();

            builder.ConfigureContainer(
                manager.GetProviderFactory(),
                (services) =>
                {
                    var reg = manager.GetRegistry();
                    reg.AddAuthorizationCore()
                        .AddFluentUIComponents((o) => { o.UseTooltipServiceProvider = true; })
                        .AddScoped<AccessProvider<Account>>()
                        .AddScoped<AuthenticationStateProvider, AccessProvider<Account>>()
                        .AddScoped<IAccountAccess, AccessProvider<Account>>();
                    reg.MergeServices(services, true);
                }
            );

            var host = builder.Build();
            manager.ReplaceProvider(host.Services);
            await host.RunAsync();
        }
    }
}
