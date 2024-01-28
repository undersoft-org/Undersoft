﻿using System.ServiceModel;

namespace Undersoft.SDK.Service.Server.Controller.Stream;

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Response;

[ServiceContract]
public interface IStreamDataController<TDto> where TDto : class, IOrigin, IInnerProxy
{
    Task<ResultString> Count();
    IAsyncEnumerable<TDto> All();
    IAsyncEnumerable<TDto> Query(QuerySet query);
    IAsyncEnumerable<ResultString> Creates(TDto[] dtos);
    IAsyncEnumerable<ResultString> Changes(TDto[] dtos);
    IAsyncEnumerable<ResultString> Updates(TDto[] dtos);
    IAsyncEnumerable<ResultString> Deletes(TDto[] dtos);
}