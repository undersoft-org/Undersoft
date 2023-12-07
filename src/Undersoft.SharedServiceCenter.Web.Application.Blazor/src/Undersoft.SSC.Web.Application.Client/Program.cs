using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application;

namespace Undersoft.SSC.Web.Application.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var app = builder.Services.AddAuthorizationCore().AddApplicationSetup();
            app.ConfigureServices(AppDomain.CurrentDomain.GetAssemblies());
            app.UseDataServices();

            await builder.Build().RunAsync();
        }
    }
}
