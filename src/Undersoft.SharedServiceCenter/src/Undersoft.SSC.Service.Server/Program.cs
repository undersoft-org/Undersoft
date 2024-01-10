using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SSC.Service.Server
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

            builder.Info<Runlog>("Starting Shared Client Center Server Client ....");

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
                Log.Error<Runlog>(null, "Shared Client Center Server Client terminated unexpectedly ....", exception);
            }
            finally
            {
                Log.Info<Runlog>(null, "Shared Client Center Server Client shutted down ....");
            }
        }

        public static async Task Restart()
        {
            Log.Info<Runlog>(null, "Restarting Shared Client Center Server Client ....");

            Task.WaitAll(Shutdown());

            await Task.Run(() => Launch());
        }

        public static async Task Shutdown()
        {
            Log.Info<Runlog>(null, "Shutting down Shared Client Center Server Client ....");

            _webapi.Info<Runlog>("Stopping Shared Client Center Server Client ....");

            if(_webapi != null)
                await _webapi.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}