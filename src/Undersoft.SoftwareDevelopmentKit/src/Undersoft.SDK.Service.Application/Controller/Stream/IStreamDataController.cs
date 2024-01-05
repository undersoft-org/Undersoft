using System.ServiceModel;

namespace Undersoft.SDK.Service.Application.Controller.Stream;

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Query;

[ServiceContract]
public interface IStreamDataController<TDto> where TDto : class, IDataObject
{
    Task<string> Count();
    IAsyncEnumerable<TDto> All();
    IAsyncEnumerable<TDto> Query(QuerySet query);
    IAsyncEnumerable<string> Creates(TDto[] dtos);
    IAsyncEnumerable<string> Changes(TDto[] dtos);
    IAsyncEnumerable<string> Updates(TDto[] dtos);
    IAsyncEnumerable<string> Deletes(TDto[] dtos);
}