using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Undersoft.SDK.Service;

namespace Undersoft.SSC.Web.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var mc = builder.Services.AddServiceSetup();

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.ConfigureContainer(ServiceManager.GetProviderFactory(), (s) =>
            {
                s.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
                s.AddAuthorizationCore();
                mc.ConfigureServices(AppDomain.CurrentDomain.GetAssemblies());
                ServiceManager.GetRegistry().MergeServices(s, true);
                ServiceManager.BuildInternalProvider().UseDataServices();
                ServiceManager.GetRegistry().MergeServices(s, true);
            });

            var host = builder.Build();

            ServiceManager.SetProvider(host.Services);

            await host.RunAsync();
        }
    }
}
