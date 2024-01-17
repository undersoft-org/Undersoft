using Undersoft.SDK.Logging;
using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SSC.Service.Application.Server;

public class Program
{
    static string[] _args = new string[0];
    static IHost? _host;

    public static void Main(string[] args)
    {
        _args = args ?? new string[0];
        Launch();
    }

    static IHost Build()
    {
        var builder = new HostBuilder();

        builder.Info<Runlog>("Starting Shared Service Center Web Server Server ....");

        _host = builder.ConfigureWebHost(builder => builder
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .ConfigureKestrel((c, o) => o
                .Configure(c.Configuration
                .GetSection("Kestrel")))
            .UseStaticWebAssets()
            .UseStartup<Startup>())
            .Build();

        return _host;
    }
    public static void Launch()
    {
        try
        {
            Build().Run();
        }
        catch (Exception exception)
        {
            Log.Error<Runlog>(null, "Shared Service Center Web Server Server terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, "Shared Service Center Web Server Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting Shared Service Center Web Server Server ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        Log.Info<Runlog>(null, "Shutting down Shared Service Center Web Server Server ....");

        _host.Info<Runlog>("Stopping Shared Service Center Web Server Server ....");

        if (_host != null)
            await _host.StopAsync(TimeSpan.FromSeconds(5));
    }
}
