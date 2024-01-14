using Microsoft.OData.Client;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Repository;

using Data.Entity;
using Instant.Rubrics;
using Microsoft.Extensions.Options;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Repository.Client;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public class RepositoryOptions
{
    public Dictionary<string, RepositorySourceOptions> Sources { get; set; }

    public Dictionary<string, RepositoryClientOptions> Clients { get; set; }
}
