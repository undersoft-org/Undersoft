using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SSC.Service.Server;

public class Program
{
    static string[] _args = new string[0];
    static IHost? _host;

    public static void Main(string[] args)
    {
        _args = args;
        Launch();
    }

    static IHost Build()
    {
        var builder = new HostBuilder();

        builder.Info<Runlog>("Starting Undersoft.SSC.Service.Server ....");

        _host = builder.ConfigureWebHost((wh) => wh
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .ConfigureKestrel((c, o) => o
                .Configure(c.Configuration
                .GetSection("Kestrel")))            
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
            Log.Error<Runlog>(null, "Undersoft.SSC.Service.Server terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, "Undersoft.SSC.Service.Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting Undersoft.SSC.Service.Server ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        Log.Info<Runlog>(null, "Shutting down Undersoft.SSC.Service.Server ....");

        _host.Info<Runlog>("Stopping Undersoft.SSC.Service.Server ....");

        if(_host != null)
            await _host.StopAsync(TimeSpan.FromSeconds(5));
    }
}