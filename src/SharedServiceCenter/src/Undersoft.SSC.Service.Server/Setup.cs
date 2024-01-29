using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server;
using Undersoft.SDK.Service.Server.Hosting;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Server;

public class Setup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddServerSetup(services.AddControllers())
            .ConfigureServer(
                true,
                new[]
                {
                    typeof(AccountStore),
                    typeof(EventStore),
                    typeof(EntryStore),
                    typeof(ReportStore)
                },
                new[] 
                {   typeof(ApplicationClient),                         
                    typeof(EventClient) 
                }
            )
            .AddAccountServer<AccountStore>()
            .AddDataServer<IEntityStore>(
                DataServerTypes.All,
                builder =>
                    builder
                        .AddInvocations<Member>()
                        .AddInvocations<Identifier<Member>>()
                        .AddInvocations<Contracts.Service>()
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
        app.UseServerSetup(env)
            .UseServiceServer(new string[] { "v1.0" })
            .UseInternalProvider()
            .UseDataMigrations()
            .UseServiceClients();
    }
}
