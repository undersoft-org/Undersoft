namespace Undersoft.SDK.Service.Operation.Invocation.Handler;

using FluentValidation.Results;
using MediatR;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Service.Operation.Invocation.Notification;

public class AccessHandler<TStore, TService, TDto>
    : IRequestHandler<Action<TStore, TService, TDto>, Invocation<TDto>>
    where TService : class
    where TDto : class, IOrigin
    where TStore : IDataServerStore
{
    protected readonly IServicer _servicer;

    public AccessHandler(IServicer servicer)
    {
        _servicer = servicer;
    }

    public async Task<Invocation<TDto>> Handle(
        Action<TStore, TService, TDto> request,
        CancellationToken cancellationToken
    )
    {
        if (!request.Result.IsValid)
            return request;
        try
        {
            request.Arguments.ResolveArgumentTypes();

            request.Response = await _servicer.Run<TService, TDto>(request.Arguments);

            if (request.Response == null)
                throw new Exception(
                    $"{GetType().Name} "
                        + $"for entity {typeof(TDto).Name} "
                        + $"unable create source"
                );

            _ = _servicer.Publish(new ActionInvoked<TStore, TService, TDto>(request)).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            request.Result.Errors.Add(new ValidationFailure(string.Empty, ex.Message));
            this.Failure<Applog>(ex.Message, request.ErrorMessages, ex);
        }
        return request;
    }
}
