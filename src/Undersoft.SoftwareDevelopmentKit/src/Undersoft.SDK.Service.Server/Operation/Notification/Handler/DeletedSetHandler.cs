﻿using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Notification.Handler;
using Logging;

using Series;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class DeletedSetHandler<TStore, TEntity, TDto>
    : INotificationHandler<DeletedSet<TStore, TEntity, TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDatabaseStore
{
    protected readonly IStoreRepository<TEntity> _repository;
    protected readonly IStoreRepository<Event> _eventStore;

    public DeletedSetHandler() { }

    public DeletedSetHandler(
        IStoreRepository<IReportStore, TEntity> repository,
        IStoreRepository<IEventStore, Event> eventStore
    )
    {
        _repository = repository;
        _eventStore = eventStore;
    }

    public virtual Task Handle(
        DeletedSet<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        return Task.Run(
            () =>
            {
                try
                {
                    request.ForOnly(
                        d => !d.Command.IsValid,
                        d =>
                        {
                            request.Remove(d);
                        }
                    );

                    _eventStore.AddAsync(request).ConfigureAwait(true);

                    if (request.PublishMode == EventPublishMode.PropagateCommand)
                    {
                        ISeries<TEntity> entities;
                        if (request.Predicate == null)
                            entities = _repository
                                .Delete(request.Select(d => (TEntity)d.Command.Entity))
                                .ToCatalog();
                        else
                            entities = _repository
                                .Delete(
                                    request.Select(d => (TEntity)d.Command.Entity),
                                    request.Predicate
                                )
                                .ToCatalog();

                        request.ForEach(
                            (r) =>
                            {
                                _ = entities.ContainsKey(r.AggregateId)
                                    ? r.PublishStatus = EventPublishStatus.Complete
                                    : r.PublishStatus = EventPublishStatus.Uncomplete;
                            }
                        );
                    }
                }
                catch (Exception ex)
                {
                    this.Failure<Domainlog>(
                        ex.Message,
                        request.Select(r => r.Command.ErrorMessages).ToArray(),
                        ex
                    );
                    request.ForEach((r) => r.PublishStatus = EventPublishStatus.Error);
                }
            },
            cancellationToken
        );
    }
}
