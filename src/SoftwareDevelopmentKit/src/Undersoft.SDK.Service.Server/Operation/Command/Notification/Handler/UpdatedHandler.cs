﻿using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Command.Notification.Handler;
using Logging;

using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Command.Notification;

public class UpdatedHandler<TStore, TEntity, TDto>
    : INotificationHandler<Updated<TStore, TEntity, TDto>>
    where TDto : class, IOrigin, IInnerProxy
    where TEntity : class, IOrigin, IInnerProxy
    where TStore : IDataServerStore
{
    protected readonly IStoreRepository<Event> _eventStore;
    protected readonly IStoreRepository<TEntity> _repository;

    public UpdatedHandler() { }

    public UpdatedHandler(
        IStoreRepository<IReportStore, TEntity> repository,
        IStoreRepository<IEventStore, Event> eventStore
    )
    {
        _repository = repository;
        _eventStore = eventStore;
    }

    public virtual Task Handle(
        Updated<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        return Task.Run(
            async () =>
            {
                try
                {
                    if (_eventStore.Add(request) == null)
                        throw new Exception(
                            $"{$"{GetType().Name} or entity "}{$"{typeof(TEntity).Name} unable add event"}"
                        );

                    if (request.Command.PublishMode == EventPublishMode.PropagateCommand)
                    {
                        TEntity result;
                        if (request.Predicate == null)
                            result = await _repository.SetBy(request.Command.Contract);
                        else if (request.Conditions == null)
                            result = await _repository.SetBy(
                                request.Command.Contract,
                                request.Predicate
                            );
                        else
                            result = await _repository.SetBy(
                                request.Command.Contract,
                                request.Predicate,
                                request.Conditions
                            );

                        if (result == null)
                            throw new Exception(
                                $"{$"{GetType().Name} for entity "}{$"{typeof(TEntity).Name} unable update report"}"
                            );

                        request.PublishStatus = EventPublishStatus.Complete;
                    }
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
