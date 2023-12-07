using NLog.Web;
using ServiceStack.Text;
using Undersoft.SDK.Logging;
using Undersoft.SDK.Service.Application;
using Undersoft.SDK.Service.Application.DataServer;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Infrastructure.Persistance.Stores;

namespace Undersoft.SSC.Web.Application.Server;

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

        var builder = WebApplication.CreateBuilder(_args);

        builder.Info<Runlog>("Starting Undersoft SSC Web Application Server ....");

        _webapi = builder.WebHost
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(ServiceConfigurationHelper.BuildConfiguration())
            .UseKestrel()
            .ConfigureKestrel((c, o) => o
                .Configure(c.Configuration
                .GetSection("Kestrel")))
            .UseStartup<Startup>()
            .UseNLog()
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
            Log.Error<Runlog>(null, "Undersoft SSC Web Application Server terminated unexpectedly ....", exception);
        }
        finally
        {
            Log.Info<Runlog>(null, "Undersoft SSC Web Application Server shutted down ....");
        }
    }

    public static async Task Restart()
    {
        Log.Info<Runlog>(null, "Restarting Undersoft SSC Web Application Server ....");

        Task.WaitAll(Shutdown());

        await Task.Run(() => Launch());
    }

    public static async Task Shutdown()
    {
        Log.Info<Runlog>(null, "Shutting down Undersoft SSC Web Application Server ....");

        _webapi.Info<Runlog>("Stopping Undersoft SSC Web Application Server ....");

        if (_webapi != null)
            await _webapi.StopAsync(TimeSpan.FromSeconds(5));
    }
}
