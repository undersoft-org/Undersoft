using IdentityModel.Client;
using Microsoft.OData;
using Microsoft.OData.Client;
using ProtoBuf.Meta;
using System.Linq.Expressions;
using System.Text.Json;

namespace Undersoft.SDK.Service.Data.Remote.Repository;

public partial class RemoteRepository<TEntity>
{
    public async Task<TEntity> Setup<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Setup", method, arguments);
    }

    public async Task<TEntity> Access<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Access", method, arguments);
    }

    public async Task<TEntity> Action<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Action", method, arguments);
    }

    private async Task<TEntity> InvokeAsync<TModel>(string action, string method, TModel args)
    {
        Arguments _args = null;
        if (typeof(TModel) != typeof(Arguments))
        {
            _args = new Arguments(method, args);
        }
        else
            _args = ((Arguments)((object)args));

        var service = new DataServiceActionQuerySingle<TEntity>(
            remoteContext,
            $"{remoteContext.BaseUri.OriginalString}/{Name}/{action}", new BodyOperationParameter(method, _args));

        var result = await service.GetValueAsync();
        return result;
    }

    private async Task<IEnumerable<TEntity>> InvokeAsync(
        string action,
        string method,
        TEntity[] args
    )
    {
        var service = new DataServiceActionQuery<TEntity>(
            remoteContext,
            $"{remoteContext.BaseUri.OriginalString}/{Name}/{action}",
            new BodyOperationParameter(method, args)
        );
        var result = await service.ExecuteAsync();
        return result;
    }
}
