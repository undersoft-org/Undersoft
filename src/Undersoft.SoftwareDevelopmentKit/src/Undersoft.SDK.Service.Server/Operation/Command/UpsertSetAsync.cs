﻿using MediatR;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Operation.Command;


using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Store;

public class UpsertSetAsync<TStore, TEntity, TDto>
    : UpsertSet<TStore, TEntity, TDto>,
        IStreamRequest<Command<TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDataServerStore
{
    public UpsertSetAsync(EventPublishMode publishPattern, TDto input, object key)
        : base(publishPattern, input, key) { }

    public UpsertSetAsync(
        EventPublishMode publishPattern,
        TDto[] inputs,
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate
    ) : base(publishPattern, inputs, predicate) { }

    public UpsertSetAsync(
        EventPublishMode publishPattern,
        TDto[] inputs,
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate,
        params Func<TEntity, Expression<Func<TEntity, bool>>>[] conditions
    ) : base(publishPattern, inputs, predicate, conditions) { }
}
