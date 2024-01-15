using FluentValidation.Results;
using MediatR;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Notification.Handler;

public class RemoteExecutedHandler<TStore, TDto, TModel, TKind>
    : INotificationHandler<RemoteExecuted<TStore, TDto, TModel, TKind>>
    where TDto : class, IOrigin
    where TModel : class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    protected readonly IStoreRepository<Event> _eventStore;

    public RemoteExecutedHandler() { }

    public RemoteExecutedHandler(
        IStoreRepository<IEventStore, Event> eventStore
    )
    {
        _eventStore = eventStore;
    }

    public virtual Task Handle(
        RemoteExecuted<TStore, TDto, TModel, TKind> request,
        CancellationToken cancellationToken
    )
    {
        return Task.Run(
            () =>
            {
                try
                {
                    if (_eventStore.Add(request) == null)
                        throw new Exception(
                            $"{$"{GetType().Name} "}{$"for contract {typeof(TModel).Name} unable add event"}"
                        );
                }
                catch (Exception ex)
                {
                    request.Command.Result.Errors.Add(
                        new ValidationFailure(string.Empty, ex.Message)
                    );
                    this.Failure<Domainlog>(ex.Message, request.Command.ErrorMessages, ex);
                    request.PublishStatus = EventPublishStatus.Error;
                }
            },
            cancellationToken
        );
    }
}
