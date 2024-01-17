namespace Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Repository.Client;

public class RepositoryOptions
{
    public Dictionary<string, RepositorySourceOptions> Sources { get; set; }

    public Dictionary<string, RepositoryClientOptions> Clients { get; set; }
}
