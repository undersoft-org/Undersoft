﻿using MediatR;



namespace Undersoft.SDK.Service.Application.Operation.Remote.Notification.Handler;

public class RemoteChangedSetHandler<TStore, TDto, TModel>
    : INotificationHandler<RemoteChangedSet<TStore, TDto, TModel>>
    where TDto : class, IDataObject
    where TModel : class, IDataObject
    where TStore : IDataServiceStore
{
    protected readonly IStoreRepository<Event> _eventStore;

    public RemoteChangedSetHandler() { }

    public RemoteChangedSetHandler(
        IStoreRepository<IEventStore, Event> eventStore
    )
    {
        _eventStore = eventStore;
    }

    public virtual async Task Handle(
        RemoteChangedSet<TStore, TDto, TModel> request,
        CancellationToken cancellationToken
    )
    {
        await Task.Run(
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
