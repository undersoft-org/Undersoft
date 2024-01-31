using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Uniques;

public interface IOpenServiceController<TKey, TService, TDto> where TDto : class
{
  
}