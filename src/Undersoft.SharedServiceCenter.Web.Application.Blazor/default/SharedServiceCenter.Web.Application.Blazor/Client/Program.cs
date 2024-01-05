using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Undersoft.SSC.Web.Infrastructure.Persistance.Services;
using Undersoft.SDK.Service;

namespace SharedServiceCenter.Web.Application.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var mc = builder.Services.AddServiceSetup();

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.ConfigureContainer(
                ServiceManager.GetProviderFactory(),
                (s) =>
                {
                    s.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
                    s.AddAuthorizationCore();
                    mc.ConfigureServices(
                        AppDomain.CurrentDomain.GetAssemblies(),
                        null,
                        new[] { typeof(OpenDataService) }
                    );
                    var reg = ServiceManager.GetRegistry();
                    reg.MergeServices(s, true);
                    ServiceManager.BuildInternalProvider().UseDataServices();
                    reg.MergeServices(s, true);
                }
            );

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            await host.RunAsync();
        }
    }
}
