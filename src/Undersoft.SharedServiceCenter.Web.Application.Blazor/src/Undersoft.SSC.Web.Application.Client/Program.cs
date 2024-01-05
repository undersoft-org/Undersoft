using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Service;

namespace Undersoft.SSC.Web.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var serviceSetup = builder.Services.AddServiceSetup();

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.ConfigureContainer(
                ServiceManager.GetProviderFactory(),
                (services) =>
                {
                    services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
                    services.AddAuthorizationCore();
                    serviceSetup.ConfigureServices(
                        AppDomain.CurrentDomain.GetAssemblies(),
                        null,
                        new[] { typeof(OpenDataServiceContext) }
                    );
                    var reg = ServiceManager.GetRegistry();
                    reg.MergeServices(services, true);
                    ServiceManager.BuildInternalProvider().UseDataServices();
                    reg.MergeServices(services, true);
                }
            );

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            await host.RunAsync();
        }
    }
}
