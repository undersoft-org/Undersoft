using Undersoft.SDK.Service.Application;
using Undersoft.SDK.Service.Application.DataServer;

namespace Undersoft.SSC.Web.Application.Server;

using Infrastructure.Persistance.Stores;
using Undersoft.SDK.Service.Data.Store;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationSetup()
            .ConfigureApplication(true, AppDomain.CurrentDomain.GetAssemblies())        
            .AddDataServer<IEventStore>(
                DataServerTypes.All,
                builder =>
                    builder.AddDataServices<AppEventStore>()
            );
        services.AddControllersWithViews();
        services.AddRazorPages();
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

        app.UseBlazorFrameworkFiles();

        app.UseInternalProvider()
            .UseApplicationSetup(env, true, true)
            .UseDataMigrations()
            .UseDataServices()
            .MapFallbackToFile("/index.html");
    }
}
