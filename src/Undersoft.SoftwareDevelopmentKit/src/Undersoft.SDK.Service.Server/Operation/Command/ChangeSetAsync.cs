﻿using MediatR;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Operation.Command;

using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store;

public class ChangeSetAsync<TStore, TEntity, TDto>
    : ChangeSet<TStore, TEntity, TDto>,
        IStreamRequest<Command<TDto>>
    where TEntity : class, IDataObject
    where TDto : class, IDataObject
    where TStore : IDataServerStore
{
    public ChangeSetAsync(EventPublishMode publishPattern, TDto input, object key)
        : base(publishPattern, input, key) { }

    public ChangeSetAsync(EventPublishMode publishPattern, TDto[] inputs)
        : base(publishPattern, inputs) { }

    public ChangeSetAsync(
        EventPublishMode publishPattern,
        TDto[] inputs,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate
    ) : base(publishPattern, inputs, predicate) { }
}
