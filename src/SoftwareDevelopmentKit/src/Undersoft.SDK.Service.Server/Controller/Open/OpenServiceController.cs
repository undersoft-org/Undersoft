using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Client.Attributes;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

[OpenService]
public abstract class OpenServiceController<TStore, TService, TModel>
    : ODataController,
        IOpenServiceController<TStore, TService, TModel>
    where TModel : class, IOrigin, IInnerProxy, new()
    where TService : class
    where TStore : IDataServerStore
{
    protected readonly IServicer _servicer;

    protected OpenServiceController() { }

    public OpenServiceController(IServicer servicer)
    {
        _servicer = servicer;
    }

    [HttpPost]
    public virtual async Task<IActionResult> Access([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
              async a =>
                  await _servicer.Perform(
                      new Action<TStore, TService, TModel>(a.Key, a.Value)
                  )
          )
          .Commit();

        object[] response = await result
        .ForEach(
                async c => (isValid = (await c).IsValid) ? c.Id as object : (await c).ErrorMessages
        )
            .ToArrayAsync();
        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }


    [HttpPost]
    public virtual async Task<IActionResult> Action([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
              async a =>
                  await _servicer.Perform(
                      new Action<TStore, TService, TModel>(a.Key, a.Value)
                  )
          )
          .Commit();

        object[] response = await result
        .ForEach(
                async c => (isValid = (await c).IsValid) ? c.Id as object : (await c).ErrorMessages
        )
            .ToArrayAsync();
        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Setup([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
              async a =>
                  await _servicer.Perform(
                      new Setup<TStore, TService, TModel>(a.Key, a.Value)
                  )
          )
          .Commit();

        object[] response = await result
        .ForEach(
                async c => (isValid = (await c).IsValid) ? c.Id as object : (await c).ErrorMessages
        )
            .ToArrayAsync();
        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }
}
