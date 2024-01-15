using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Application.Hosting;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Server;

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
                    typeof(ServiceAccountStore),
                    typeof(ServiceEventStore)
                },
                new[]
                {
                    typeof(MemberDataService),
                    typeof(ActivityDataService),
                    typeof(ResourceDataService),
                    typeof(ScheduleDataService)
                }
            )
            .AddAccountServer<ServiceAccountStore>()
            .AddDataServer<IDataServiceStore>(
                DataServerTypes.All,
                builder => builder.AddAccountServices<Authorization>()
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseServerSetup(env)
            .UseApiServerSetup(new string[] { "v1.0" })
            .UseInternalProvider()
            .UseDataMigrations();
    }
}
