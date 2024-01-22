using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Command.Handler;

using Microsoft.AspNetCore.Http;
using Notification;
using Undersoft.SDK;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

public class RemoteInvokeHandler<TStore, TService, TModel>
    : IRequestHandler<RemoteInvoke<TStore, TService, TModel>, Invocation<TModel>>
    where TService : class
    where TModel : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
{
    protected readonly IRemoteRepository<TModel> _repository;
    protected readonly IServicer _servicer;

    public RemoteInvokeHandler(IServicer servicer, IRemoteRepository<TStore, TModel> repository)
    {
        _repository = repository;
        _servicer = servicer;
    }

    public async Task<Invocation<TModel>> Handle(
        RemoteInvoke<TStore, TService, TModel> request,
        CancellationToken cancellationToken
    )
    {
        if (!request.Result.IsValid)
            return request;
        try
        {
            request.Response = (
                request.CommandMode == CommandMode.Action
                    ? await _repository.ActionAsync<TService>(request.Method,
                        request.Arguments              
                    )
                    : await _repository.FunctionAsync<TService>(request.Method)
            );

            if (request.Response == null)
                throw new Exception(
                    $"{GetType().Name} "
                        + $"for entity {typeof(TModel).Name} "
                        + $"unable create source"
                );

            await _servicer
                .Publish(new RemoteInvoked<TStore, TService, TModel>(request))
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            request.Result.Errors.Add(new ValidationFailure(string.Empty, ex.Message));
            this.Failure<Applog>(ex.Message, request.ErrorMessages, ex);
        }
        return request;
    }
}
