using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SSC.Service.Server;

public class Program
{
    static string[] _arguments = new string[0];
    static ServerHost _superServer = new ServerHost();
    static ISeries<ServerHost> _servers = new Registry<ServerHost>();

    public static void Main(string[] arguments)
    {
        _arguments = arguments;
        Launch();
    }

    static IHost ServerBuild()
    {
        var builder = new HostBuilder();

        builder.Info<Runlog>("Starting Undersoft.SSC.Service.Server ....");

        return builder.ConfigureWebHost((wh) => wh
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .ConfigureKestrel((c, o) => o
                .Configure(c.Configuration
                .GetSection("Kestrel")))            
            .UseStartup<Startup>())
            .Build();
    }

    public static async void Launch()
    {
        try
        {                
            _superServer.Host = ServerBuild();
            _superServer.Host.Start();
            await _superServer.Host.WaitForShutdownAsync();
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

        _superServer.Info<Runlog>("Stopping Undersoft.SSC.Service.Server ....");

        if(_superServer.Host != null)
            await _superServer.Host.StopAsync(TimeSpan.FromSeconds(5));
    }
}