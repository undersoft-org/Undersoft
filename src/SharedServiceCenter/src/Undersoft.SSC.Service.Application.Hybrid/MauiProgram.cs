using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.AspNetCore.Components.Authorization;
using Undersoft.SDK.Service;
using Undersoft.SSC.Service.Clients;
using Undersoft.SDK.Service.Application.Access;

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
                .ConfigureServices(null, new[] { typeof(ApplicationClient) });

            _ = setup.Manager.BuildInternalProvider().UseServiceClients();

            builder.ConfigureContainer(
                setup.Manager.GetProviderFactory(),
                (services) =>
                {
                    var reg = setup.Services;
                    reg.Services = services;
                    reg.AddAuthorizationCore();
                    reg.AddScoped<AccessProvider>();
                    reg.AddScoped<AuthenticationStateProvider, AccessProvider>(
                        provider =>
                            provider.GetRequiredService<AccessProvider>()
                    );
                    reg.AddScoped<IAccessService, AccessProvider>(
                        provider =>
                            provider.GetRequiredService<AccessProvider>()
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
