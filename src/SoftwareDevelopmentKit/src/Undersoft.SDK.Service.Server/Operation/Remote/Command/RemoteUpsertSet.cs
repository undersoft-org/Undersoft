﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;


using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Store;

public class RemoteUpsertSet<TStore, TDto, TModel> : RemoteCommandSet<TModel>
    where TDto : class, IOrigin, IInnerProxy
    where TModel : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
{
    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>> Predicate { get; }

    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>>[] Conditions { get; }

    public RemoteUpsertSet(EventPublishMode publishPattern, TModel input, object key)
        : base(
            CommandMode.Change,
            publishPattern,
            new[]
            {
                new RemoteUpsert<TStore, TDto, TModel>(
                    publishPattern,
                    input,
                    e => e => e.Id == (long)key
                )
            }
        ) { }

    public RemoteUpsertSet(
        EventPublishMode publishPattern,
        TModel[] inputs,
        Func<TDto, Expression<Func<TDto, bool>>> predicate
    )
        : base(
            CommandMode.Upsert,
            publishPattern,
            inputs
                .Select(
                    input => new RemoteUpsert<TStore, TDto, TModel>(publishPattern, input, predicate)
                )
                .ToArray()
        )
    {
        Predicate = predicate;
    }

    public RemoteUpsertSet(
        EventPublishMode publishPattern,
        TModel[] inputs,
        Func<TDto, Expression<Func<TDto, bool>>> predicate,
        params Func<TDto, Expression<Func<TDto, bool>>>[] conditions
    )
        : base(
            CommandMode.Upsert,
            publishPattern,
            inputs
                .Select(
                    input =>
                        new RemoteUpsert<TStore, TDto, TModel>(
                            publishPattern,
                            input,
                            predicate,
                            conditions
                        )
                )
                .ToArray()
        )
    {
        Predicate = predicate;
        Conditions = conditions;
    }
}
