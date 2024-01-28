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

        builder.Info<Runlog>("Starting Undersoft.SSC.Service.Application.Server ....");

        _host = builder.ConfigureWebHost(builder => builder
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .ConfigureKestrel((c, o) => o
                .Configure(c.Configuration
                .GetSection("Kestrel")))
            .UseStaticWebAssets()
            .UseStartup<Setup>())
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
            Log.Error<Runlog>(null, " Undersoft.SSC.Service.Application.Server terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, " Undersoft.SSC.Service.Application.Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting  Undersoft.SSC.Service.Application.Server ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        _host.Info<Runlog>("Shutting down  Undersoft.SSC.Service.Application.Server ....");

        if (_host != null)
            await _host.StopAsync(TimeSpan.FromSeconds(5));
    }
}
