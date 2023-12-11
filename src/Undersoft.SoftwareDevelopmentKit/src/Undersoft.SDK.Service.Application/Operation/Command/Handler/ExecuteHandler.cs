﻿namespace Undersoft.SDK.Service.Application.Operation.Command.Handler;

using FluentValidation.Results;
using MediatR;
using Undersoft.SDK.Service.Application.Operation.Notification;
using SDK.Service.Data.Store;
using Undersoft.SDK;

public class ExecuteHandler<TStore, TType, TDto, TKind>
    : IRequestHandler<Execute<TStore, TType, TDto, TKind>, ActionCommand<TDto, TKind>>
    where TType : class
    where TDto : class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;
    protected readonly TType _service;

    public ExecuteHandler(IServicer servicer, TType service)
    {
        _servicer = servicer;
        _service = service;
    }

    public async Task<ActionCommand<TDto, TKind>> Handle(
        Execute<TStore, TType, TDto, TKind> request,
        CancellationToken cancellationToken
    )
    {
        if (!request.Result.IsValid)
            return request;
        try
        {
            request.Response =
                await new Invoker<TType>(request.Kind.ToString(), request.Data).InvokeAsync(cancellationToken);

            _ = _servicer.Publish(new Executed<TStore, TType, TDto, TKind>(request)).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            request.Result.Errors.Add(new ValidationFailure(string.Empty, ex.Message));
            this.Failure<Applog>(ex.Message, request.ErrorMessages, ex);
        }
        return request;
    }
}
