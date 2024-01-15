using Undersoft.SDK.Logging;
using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SSC.Service.Application.Server;

public class Program
{
    static string[] _args = new string[0];
    static IWebHost? _webapi;

    public static void Main(string[] args)
    {
        _args = args ?? new string[0];
        Launch();
    }

    static IWebHost Build()
    {

        var builder = new WebHostBuilder();

        builder.Info<Runlog>("Starting Shared Client Center Web Server Server ....");

        _webapi = builder
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .UseStaticWebAssets()
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
            Log.Error<Runlog>(null, "Shared Client Center Web Server Server terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, "Shared Client Center Web Server Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting Shared Client Center Web Server Server ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        Log.Info<Runlog>(null, "Shutting down Shared Client Center Web Server Server ....");

        _webapi.Info<Runlog>("Stopping Shared Client Center Web Server Server ....");

        if (_webapi != null)
            await _webapi.StopAsync(TimeSpan.FromSeconds(5));
    }
}
