﻿using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Notification.Handler;
using Logging;

using Undersoft.SDK.Service.Data.Entity;

using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Repository;

public class ExecutedHandler<TStore, TType, TDto, TKind>
    : INotificationHandler<Executed<TStore, TType, TDto, TKind>>
    where TType : class
    where TDto :  class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    protected readonly IStoreRepository<Event> _eventStore;

    public ExecutedHandler() { }

    public ExecutedHandler(
        IStoreRepository<IEventStore, Event> eventStore
    )
    {
        _eventStore = eventStore;
    }

    public virtual Task Handle(
        Executed<TStore, TType, TDto, TKind> request,
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
                            $"{$"{GetType().Name} "}{$"for invoke {typeof(TType).Name} unable add event"}"
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