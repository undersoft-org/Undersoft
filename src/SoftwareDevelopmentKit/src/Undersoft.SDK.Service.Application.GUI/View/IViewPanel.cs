﻿using Undersoft.SDK.Instant.Proxies;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewPanel<TModel> : IViewDialog<TModel> where TModel : class, IOrigin, IInnerProxy
    {
    }
}