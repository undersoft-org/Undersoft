using Serilog;
using Undersoft.SDK.Service.Application;
using Undersoft.SDK.Service.Application.DataServer;
using Undersoft.SSC.Infrastructure.Persistance.Stores;
using Undersoft.SSC.Web.Infrastructure.Persistance.Services;

namespace Undersoft.SSC.Web.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            var setup = services.AddApplicationSetup(services.AddControllers());
            setup
                .ConfigureApplication(
                    true,
                    AppDomain.CurrentDomain.GetAssemblies(),
                    new[]
                    {
                        typeof(ServiceEntryStore),
                        typeof(ServiceReportStore),
                        typeof(ServiceIdentityStore),
                        typeof(ServiceEventStore)
                    }
                )
                .AddIdentityService<ServiceIdentityStore>()
                .AddDataServer<IDataServiceStore>(
                    DataServerTypes.All,
                    builder => builder.AddIdentityActionSet()
                );
            setup.AddCaching();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApplicationSetup(env)
                .UseApiSetup(new string[] { "v1.0" })
                .UseInternalProvider()
                .UseDataMigrations();
        }
    }
}
