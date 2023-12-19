using Undersoft.SDK.Service.Application;
using Undersoft.SDK.Service.Application.DataServer;

namespace Undersoft.SSC.Web.Application.Server;

using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Infrastructure.Persistance.Stores;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        var setup = services.AddApplicationSetup();
        setup
            .ConfigureApplication(true, AppDomain.CurrentDomain.GetAssemblies())
            .AddDataServer<IEventStore>(
                DataServerTypes.All,
                builder => builder.AddDataServices<AppEventStore>()
            );
        setup.AddCaching();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var a = app.UseApplicationSetup(env, true, true);
        app.UseBlazorFrameworkFiles();
        a.UseInternalProvider()
            .UseDataMigrations()
            .UseDataServices()
            .MapFallbackToFile("/index.html");
    }
}
