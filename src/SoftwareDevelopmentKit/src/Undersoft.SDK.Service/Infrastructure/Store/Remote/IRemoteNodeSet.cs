﻿using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SDK.Service.Infrastructure.Store.Relation
{
    public interface IRemoteNodeSet<TLeft, TRight>
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        object this[object key] { get; set; }

        IRemoteLink<TLeft, TRight> Single { get; }
    }
}