using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SSC.Web.Service
{
    public class Program
    {
        static string[]? _args;
        static IWebHost? _webapi;

        public static void Main(string[] args)
        {
            _args = args;
            Launch();
        }

        static IWebHost Build()
        {
            var builder = new WebHostBuilder();

            builder.Info<Runlog>("Starting Shared Service Center Web Service ....");

            _webapi = builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
                .UseKestrel()
                .ConfigureKestrel((c, o) => o
                    .Configure(c.Configuration
                    .GetSection("Kestrel")))
                .UseStartup<Startup>()
                .Build();

            return _webapi;
        }

        public static void Launch()
        {
            try
            {                
                Build().Run();
            }
            catch (Exception exception)
            {
                Log.Error<Runlog>(null, "Shared Service Center Web Service terminated unexpectedly ....", exception);
            }
            finally
            {
                Log.Info<Runlog>(null, "Shared Service Center Web Service shutted down ....");
            }
        }

        public static async Task Restart()
        {
            Log.Info<Runlog>(null, "Restarting Shared Service Center Web Service ....");

            Task.WaitAll(Shutdown());

            await Task.Run(() => Launch());
        }

        public static async Task Shutdown()
        {
            Log.Info<Runlog>(null, "Shutting down Shared Service Center Web Service ....");

            _webapi.Info<Runlog>("Stopping Shared Service Center Web Service ....");

            if(_webapi != null)
                await _webapi.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}