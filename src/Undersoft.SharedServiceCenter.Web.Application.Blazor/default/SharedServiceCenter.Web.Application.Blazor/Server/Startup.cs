using Undersoft.SDK.Service.Application;
using Undersoft.SDK.Service.Application.DataServer;

namespace SharedServiceCenter.Web.Application.Server;

using Microsoft.AspNetCore.OData;
using System.Diagnostics;
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
        var setup = services.AddApplicationSetup();
        setup.Services.AddControllersWithViews();
        setup.Services.AddRazorPages();
        setup.ConfigureApplication(true, AppDomain.CurrentDomain.GetAssemblies())
            .AddDataServer<IEventStore>(
                DataServerTypes.All,
                builder => builder.AddDataServices<AppEventStore>()
            );
        setup.AddCaching();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var appSetup = app.UseApplicationSetup(env);

        appSetup
            .UseCustomSetup(setup =>
            {
                setup.UseHeaderForwarding();

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseWebAssemblyDebugging();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();

                app.UseODataBatching();
                app.UseODataQueryRequest();

                app.UseBlazorFrameworkFiles();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseCors();

                setup.UseSwaggerSetup(new[] { "v1.0" });

                app.UseAuthentication();
                app.UseAuthorization();

                setup.UseEndpoints(true);
            });
        appSetup
            .UseInternalProvider()
            .UseDataMigrations()
            .UseDataServices();
    }
}
