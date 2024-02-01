using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using System.Text.Json;
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
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Action<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        if (result.Length < 2)
            return Ok(result.FirstOrDefault()?.Result.Output.ToJsonBytes());

        return Ok(result.Select(r => r.Result.Output).Commit());
    }

    [HttpPost]
    public virtual IActionResult Action([FromBody] IDictionary<string, Arguments> args)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Action<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        if (result.Length < 2)
            return Ok(result.FirstOrDefault()?.Result.Output.ToJsonBytes());

        return Ok(result.Select(r => r.Result.Output).Commit());
    }

    [HttpPost]
    public virtual IActionResult Setup([FromBody] IDictionary<string, Arguments> args)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = args.ForEach(
                async a =>
                    await _servicer.Perform(new Setup<TStore, TService, TModel>(a.Key, a.Value))
            )
            .Commit();

        Task.WaitAll(result);

        if (result.Length < 2)
            return Ok(result.FirstOrDefault()?.Result.Output.ToJsonBytes());

        return Ok(result.Select(r => r.Result.Output).Commit());
    }
}
