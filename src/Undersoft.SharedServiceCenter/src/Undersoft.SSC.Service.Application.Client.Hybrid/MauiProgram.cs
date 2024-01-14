using Microsoft.AspNetCore.Components.Authorization;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Services;
using Undersoft.SSC.Service.Clients;

namespace Undersoft.SSC.Service.Application.Client.Hybrid
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

            builder.Services
                .AddServiceSetup(builder.Configuration)
                .ConfigureServices(
                    AppDomain.CurrentDomain.GetAssemblies(),
                    null,
                    new[] { typeof(OpenDataService) }
                );

            _ = ServiceManager.BuildInternalProvider().UseDataServices();

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

            return host;
        }
    }
}
