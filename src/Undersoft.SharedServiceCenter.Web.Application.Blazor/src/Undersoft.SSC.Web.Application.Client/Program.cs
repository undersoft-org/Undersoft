using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service;

namespace Undersoft.SSC.Web.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.ConfigureContainer(ServiceManager.GetProviderFactory());

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddServiceSetup().ConfigureServices();

            var host = builder.Build();
            
            host.Services.UseDataServices();
            
            await host.RunAsync();
        }
    }
}
