using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Command.Handler;

using Microsoft.AspNetCore.Http;
using Notification;
using Undersoft.SDK;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteExecuteHandler<TStore, TDto, TModel, TKind>
    : IRequestHandler<RemoteExecute<TStore, TDto, TModel, TKind>, ActionCommand<TModel, TKind>>
    where TDto : class, IOrigin, IInnerProxy
    where TModel : class, IOrigin, IInnerProxy
    where TKind : Enum
    where TStore : IDataServiceStore
{
    protected readonly IRemoteRepository<TModel> _repository;
    protected readonly IServicer _servicer;

    public RemoteExecuteHandler(IServicer servicer, IRemoteRepository<TStore, TModel> repository)
    {
        _repository = repository;
        _servicer = servicer;
    }

    public async Task<ActionCommand<TModel, TKind>> Handle(
        RemoteExecute<TStore, TDto, TModel, TKind> request,
        CancellationToken cancellationToken
    )
    {
        if (!request.Result.IsValid)
            return request;
        try
        {
            request.Response = (
                request.CommandMode == CommandMode.Action
                    ? await _repository.ActionAsync<TDto, TKind>(
                        request.Data,
                        (TKind)request.Kind
                    )
                    : await _repository.FunctionAsync<TDto, TKind>((TKind)request.Kind)
            );

            if (request.Response == null)
                throw new Exception(
                    $"{GetType().Name} "
                        + $"for entity {typeof(TDto).Name} "
                        + $"unable create source"
                );

            await _servicer
                .Publish(new RemoteExecuted<TStore, TDto, TModel, TKind>(request))
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
