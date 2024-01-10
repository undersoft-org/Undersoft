using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Server.Controller.Open;


using Uniques;

public interface IOpenDataActionController<TKey, TKind, TEntity, TDto> where TDto : class where TKind : Enum
{
}