using System.ServiceModel;

namespace Undersoft.SDK.Service.Server.Controller.Stream;

using Undersoft.SDK.Service.Data.Query;

[ServiceContract]
public interface IStreamEventController<TDto> where TDto : class, IDataObject
{
    int Count();
    IAsyncEnumerable<TDto> All();
    IAsyncEnumerable<TDto> Query(QuerySet query);
    IAsyncEnumerable<string> Creates(TDto[] dtos);
    IAsyncEnumerable<string> Changes(TDto[] dtos);
    IAsyncEnumerable<string> Updates(TDto[] dtos);
    IAsyncEnumerable<string> Deletes(TDto[] dtos);
}