﻿using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Query.Handler;

using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class GetQueryHandler<TStore, TEntity, TDto>
    : IRequestHandler<GetQuery<TStore, TEntity, TDto>, IQueryable<TDto>>
    where TEntity : class, IDataObject
    where TStore : IDataServerStore
    where TDto : class
{
    protected readonly IStoreRepository<TEntity> _repository;

    public GetQueryHandler(IStoreRepository<TStore, TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<IQueryable<TDto>> Handle(
        GetQuery<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        if (request.Predicate != null)
            return await _repository.GetQueryAsync<TDto>(request.Predicate, request.Sort, request.Expanders);
        else
            return await _repository.GetQueryAsync<TDto>(request.Sort, request.Expanders);
    }
}
