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
    public virtual IActionResult Access([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Action<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        var response = result
            .ForEach(c => (isValid = c.Result.IsValid) ? c.Result.Output : c.Result.ErrorMessages)
            .Commit();

        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }

    [HttpPost]
    public virtual IActionResult Action([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Action<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        var response = result
            .ForEach(c => (isValid = c.Result.IsValid) ? c.Result.Output : c.Result.ErrorMessages)
            .Commit();

        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }

    [HttpPost]
    public virtual IActionResult Setup([FromBody] IDictionary<string, Arguments> args)
    {
        var isValid = false;

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Setup<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        var response = result
              .ForEach(c => (isValid = c.Result.IsValid) ? c.Result.Output : c.Result.ErrorMessages)
              .Commit();

        return !isValid ? UnprocessableEntity(response) : Ok(response);
    }
}
