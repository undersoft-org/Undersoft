using Microsoft.AspNetCore.Components.Authorization;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Hybrid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            var setup = builder.Services
                .AddServiceSetup(builder.Configuration)
                .ConfigureServices(new[] { typeof(ApplicationClient) });

            _ = setup.Manager.BuildInternalProvider().UseServiceClients();

            builder.ConfigureContainer(
                 setup.Manager.GetProviderFactory(),
                 (services) =>
                 {
                     var reg = setup.Manager.GetRegistry();
                     reg.Services = services;
                     reg.AddAuthorizationCore();
                     reg.AddScoped<AccessProvider<Account>>();
                     reg.AddScoped<AuthenticationStateProvider, AccessProvider<Account>>(
                         provider => provider.GetRequiredService<AccessProvider<Account>>()
                     );
                     reg.AddScoped<IAccountAccess, AccessProvider<Account>>(
                         provider => provider.GetRequiredService<AccessProvider<Account>>()
                     );
                     reg.MergeServices(true);
                 }
             );

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            return host;
        }
    }
}
