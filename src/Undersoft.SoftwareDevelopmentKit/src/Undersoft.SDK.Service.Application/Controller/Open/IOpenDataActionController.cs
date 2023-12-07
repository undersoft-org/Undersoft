using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Application.Controller.Open;


using Uniques;

public interface IOpenDataActionController<TKey, TEntity, TDto, TKind> where TDto : class where TKind : Enum
{
    Task<IActionResult> Post([FromODataBody] TDto dto);
}