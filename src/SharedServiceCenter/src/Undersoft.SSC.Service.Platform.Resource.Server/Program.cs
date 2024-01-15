using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SSC.Service.Platform.Resource.Server;

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

        builder.Info<Runlog>("Starting Undersoft.SSC.Service.Platform.Resources.Server ....");

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
            Log.Error<Runlog>(null, "Undersoft.SSC.Service.Platform.Resources.Server  terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, "Undersoft.SSC.Service.Platform.Resources.Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting Undersoft.SSC.Service.Platform.Resources.Server  ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        Log.Info<Runlog>(null, "Shutting down Undersoft.SSC.Service.Platform.Resources.Server  ....");

        _webapi.Info<Runlog>("Stopping Undersoft.SSC.Service.Platform.Resources.Server  ....");

        if (_webapi != null)
            await _webapi.StopAsync(TimeSpan.FromSeconds(5));
    }
}