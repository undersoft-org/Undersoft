using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Microsoft.AspNetCore.OData.Formatter;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation;
using Undersoft.SDK.Service.Data.Client.Attributes;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using System.Text.Json;

[OpenServiceRemote]
public abstract class OpenServiceRemoteController<TStore, TService, TDto>
    : ODataController,
        IOpenDataActionRemoteController<TStore, TService, TDto>
    where TService : class
    where TDto : class
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;

    protected OpenServiceRemoteController() { }

    public OpenServiceRemoteController(IServicer servicer)
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
                        new RemoteAction<TStore, TService, TDto>(a.Key, a.Value)
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
                        new RemoteAction<TStore, TService, TDto>(a.Key, a.Value)
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
                        new RemoteAction<TStore, TService, TDto>(a.Key, a.Value)
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
