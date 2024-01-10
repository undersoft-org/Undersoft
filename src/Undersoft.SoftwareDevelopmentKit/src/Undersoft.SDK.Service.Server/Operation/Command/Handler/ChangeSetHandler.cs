﻿using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Command.Handler;

using Logging;
using Notification;

using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class ChangeSetHandler<TStore, TEntity, TDto>
    : IRequestHandler<ChangeSet<TStore, TEntity, TDto>, CommandSet<TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDatabaseStore
{
    protected readonly IStoreRepository<TEntity> _repository;
    protected readonly IServicer _servicer;

    public ChangeSetHandler(IServicer servicer, IStoreRepository<TStore, TEntity> repository)
    {
        _servicer = servicer;
        _repository = repository;
    }

    public virtual async Task<CommandSet<TDto>> Handle(
        ChangeSet<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            IEnumerable<TEntity> entities;
            if (request.Predicate == null)
                entities = _repository.PatchBy(request.ForOnly(d => d.IsValid, d => d.Contract));
            else
                entities = _repository.PatchBy(
                    request.ForOnly(d => d.IsValid, d => d.Contract),
                    request.Predicate
                );

            await entities
                .ForEachAsync(
                    (e) =>
                    {
                        request[e.Id].Entity = e;
                    }
                )
                .ConfigureAwait(false);

            _ = _servicer
                .Publish(new ChangedSet<TStore, TEntity, TDto>(request))
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this.Failure<Domainlog>(ex.Message, request.Select(r => r.Output).ToArray(), ex);
        }
        return request;
    }
}
