﻿using MediatR;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Operation.Remote.Query;

namespace Undersoft.SDK.Service.Operation.Remote.Query.Handler;

public class RemoteGetHandler<TStore, TDto, TModel>
    : IRequestHandler<RemoteGet<TStore, TDto, TModel>, ISeries<TModel>>
    where TDto : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
{
    protected readonly IRemoteRepository<TDto> _repository;

    public RemoteGetHandler(IRemoteRepository<TStore, TDto> repository)
    {
        _repository = repository;
    }

    public virtual Task<ISeries<TModel>> Handle(
        RemoteGet<TStore, TDto, TModel> request,
        CancellationToken cancellationToken
    )
    {
        return _repository.Get<TModel>(
            request.Offset,
            request.Limit,
            request.Sort,
            request.Expanders
        );
    }
}
