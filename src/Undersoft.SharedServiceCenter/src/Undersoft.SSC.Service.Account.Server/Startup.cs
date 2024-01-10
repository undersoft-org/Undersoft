using Undersoft.SDK.Service.Server;
using Undersoft.SDK.Service.Client;
using Undersoft.SSC.Service.Infrastructure.Stores;
using Undersoft.SSC.Service.Clients;

namespace Undersoft.SSC.Service.Account.Server;

public class Startup
{
    public IConfiguration Configuration { get; }

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
                    typeof(ServiceEntryStore),
                    typeof(ServiceReportStore),
                    typeof(ServiceEventStore)
                },
                new[]
                {
                    typeof(ActivityDataService),
                    typeof(ResourceDataService),
                    typeof(ScheduleDataService)
                }
            )
            .AddDataServer<IDataServiceStore>(
                DataServerTypes.All
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseServerSetup(env)
            .UseApiSetup(new string[] { "v1.0" })
            .UseInternalProvider()
            .UseDataMigrations();
    }
}
