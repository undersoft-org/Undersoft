﻿namespace Undersoft.SDK.Service.Server.Operation.Invocation.Handler;

using FluentValidation.Results;
using MediatR;
using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Invocation.Notification;

public class FunctionHandler<TStore, TService, TDto>
    : IRequestHandler<Function<TStore, TService, TDto>, Invocation<TDto>>
    where TService : class
    where TDto : class, IOrigin
    where TStore : IDataServerStore
{
    protected readonly IServicer _servicer;

    public FunctionHandler(IServicer servicer)
    {
        _servicer = servicer;
    }

    public async Task<Invocation<TDto>> Handle(
        Function<TStore, TService, TDto> request,
        CancellationToken cancellationToken
    )
    {
        if (!request.Result.IsValid)
            return request;
        try
        {
            request.Response = await _servicer.Run<TService, TDto>(request.Method, request.Arguments);               

            _ = _servicer.Publish(new FunctionInvoked<TStore, TService, TDto>(request)).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            request.Result.Errors.Add(new ValidationFailure(string.Empty, ex.Message));
            this.Failure<Applog>(ex.Message, request.ErrorMessages, ex);
        }
        return request;
    }
}
