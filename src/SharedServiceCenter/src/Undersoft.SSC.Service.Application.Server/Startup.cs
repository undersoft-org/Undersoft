namespace Undersoft.SSC.Service.Application.Server;

using Microsoft.AspNetCore.OData;
using Undersoft.SDK.Service.Server;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Clients;
using Undersoft.SDK.Service.Server.Hosting;
using Undersoft.SSC.Service.Infrastructure.Stores;
using Undersoft.SDK.Service.Data.Event;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var setup = services.AddServerSetup();
        setup.Services.AddControllersWithViews();
        setup.Services.AddRazorPages();
        setup
            .ConfigureServer(
                true,
                AppDomain.CurrentDomain.GetAssemblies(),
                new[]
                {
                    typeof(EventStore),
                    typeof(ReportStore),
                    typeof(EntryStore)
                }
                //,new[] { typeof(ServiceClient) }
            )
            .AddDataServer<IEntityStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Contracts.Member>()
                                  .AddInvocations<Contracts.Application>()
            )
            .AddDataServer<IAccountStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Contracts.Account>()
            )
            .AddDataServer<IEventStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Event>()
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var appSetup = app.UseServerSetup(env);

        appSetup.UseCustomSetup(setup =>
        {
            setup.UseHeaderForwarding();

            if (env.IsDevelopment())
            {
                setup.Application.UseDeveloperExceptionPage();
                setup.Application.UseWebAssemblyDebugging();
            }
            else
            {
                setup.Application.UseExceptionHandler("/Error");
                setup.Application.UseHsts();
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

            setup.UseJwtMiddleware();

            setup.UseEndpoints(true);
        });

        appSetup
            .UseInternalProvider()
            .UseDataMigrations()
            .UseDataServices();
    }
}
