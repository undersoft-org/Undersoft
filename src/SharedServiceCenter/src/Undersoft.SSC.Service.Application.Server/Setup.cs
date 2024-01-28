namespace Undersoft.SSC.Service.Application.Server;

using Undersoft.SDK.Service.Application.Server;
using Undersoft.SDK.Service.Application.Server.Hosting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Infrastructure.Stores;

public class Setup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationServerSetup()
            .ConfigureApplicationServer(
                true,
                new[] { typeof(EventStore), typeof(ReportStore), typeof(EntryStore) },
                new[] { typeof(ServiceClient), typeof(AccessClient) }
            )
            .AddDataServer<IEntityStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Member>().AddInvocations<Application>()
            )
            .AddDataServer<IAccountStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Account>()
            )
            .AddDataServer<IEventStore>(
                DataServerTypes.All,
                builder => builder.AddInvocations<Event>()
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseApplicationTracking()
            .UseApplicationServerSetup(env)
            .UseServiceApplication()
            .UseInternalProvider()
            .UseDataMigrations()
            .UseServiceClients();
    }
}
