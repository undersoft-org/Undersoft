using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Server;
using Undersoft.SDK.Service.Server.Hosting;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Server;

public class Startup
{
    public IConfiguration Configuration { get; }
    public IServiceManager ServiceManager { get; set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var setup = services.AddServerSetup(services.AddControllers());
        setup
            .ConfigureServer(
                true,
                AppDomain.CurrentDomain.GetAssemblies(),
                new[]
                {
                    typeof(AccountStore),
                    typeof(EventStore),
                    typeof(EntryStore),
                    typeof(ReportStore)
                },
                new[] { typeof(ApplicationClient) }
            )
            .AddAccountServer<AccountStore>()
            .AddDataServer<IDataServiceStore>(
                DataServerTypes.All,
                builder => builder.AddAccountServices<Authorization>()
            );
        ServiceManager = setup.Manager;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseServerSetup(env)
            .UseApiServerSetup(new string[] { "v1.0" })
            .UseInternalProvider()
            .UseDataMigrations()
            .UseDataServices();
    }
}
