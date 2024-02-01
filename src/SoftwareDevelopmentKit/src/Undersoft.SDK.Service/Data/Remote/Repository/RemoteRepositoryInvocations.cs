using IdentityModel.Client;
using Microsoft.OData;
using Microsoft.OData.Client;
using ProtoBuf.Meta;
using System.Linq.Expressions;
using System.Text.Json;

namespace Undersoft.SDK.Service.Data.Remote.Repository;

public partial class RemoteRepository<TEntity>
{
    public async Task<TModel> Setup<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Setup", method, arguments);
    }

    public async Task<TModel> Access<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Access", method, arguments);
    }

    public async Task<TModel> Action<TModel>(string method, TModel arguments)
    {
        return await InvokeAsync("Action", method, arguments);
    }

    private async Task<TModel> InvokeAsync<TModel>(string action, string method, TModel args)
    {
        var edge = false; 
        Arguments _args = null;
        if (typeof(TModel) != typeof(Arguments))
        {
            _args = new Arguments(method, args);
            edge = true;
        }
        else
            _args = ((Arguments)((object)args));

        var service =
            remoteContext.ExecuteAsync<byte[]>(new Uri(
            $"{remoteContext.BaseUri.OriginalString}/{Name}/{action}"), "POST",
            new BodyOperationParameter(method, _args)
        );

        var result = await service;
        return result.FirstOrDefault().FromJson<TModel>();
    }

    private async Task<IEnumerable<TEntity>> InvokeAsync<TModel>(
        string action,
        string method,
        TModel[] args
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
