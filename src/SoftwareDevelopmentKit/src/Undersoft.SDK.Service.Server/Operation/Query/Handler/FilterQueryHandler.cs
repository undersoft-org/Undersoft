﻿using MediatR;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Server.Operation.Query.Handler;

using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class FilterQueryHandler<TStore, TEntity, TDto>
    : IRequestHandler<Filter<TStore, TEntity, TDto>, ISeries<TDto>>
    where TEntity : class, IOrigin, IInnerProxy
    where TStore : IDataServerStore
{
    protected readonly IStoreRepository<TEntity> _repository;

    public FilterQueryHandler(IStoreRepository<TStore, TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<ISeries<TDto>> Handle(
        Filter<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        Task<ISeries<TDto>> result;
        if (request.Predicate == null)
            result = _repository.Filter<TDto>(
                request.Offset,
                request.Limit,
                request.Sort,
                request.Expanders
            );
        else
        result = _repository.Filter<TDto>(
            request.Offset,
            request.Limit,
            request.Predicate,
            request.Sort,
            request.Expanders
        );
        result.Wait(10 * 10 * 100);
        return await result;
    }
}
