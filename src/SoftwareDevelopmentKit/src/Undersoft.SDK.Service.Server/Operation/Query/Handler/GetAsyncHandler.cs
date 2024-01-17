﻿using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Query.Handler;

using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

public class GetAsyncHandler<TStore, TEntity, TDto>
    : IStreamRequestHandler<GetAsync<TStore, TEntity, TDto>, TDto>
    where TEntity : class, IDataObject
    where TStore : IDataServerStore
    where TDto : class
{
    protected readonly IStoreRepository<TEntity> _repository;

    public GetAsyncHandler(IStoreRepository<TStore, TEntity> repository)
    {
        _repository = repository;
    }

    public virtual IAsyncEnumerable<TDto> Handle(
        GetAsync<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        return _repository.GetAsync<TDto>(
            request.Offset,
            request.Limit,
            request.Sort,
            request.Expanders
        );
    }
}