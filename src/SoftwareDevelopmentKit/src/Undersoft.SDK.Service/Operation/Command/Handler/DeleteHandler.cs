using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Operation.Command.Handler;
using Logging;
using Notification;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;
using Undersoft.SDK.Service.Operation.Command;

public class DeleteHandler<TStore, TEntity, TDto>
    : IRequestHandler<Delete<TStore, TEntity, TDto>, Command<TDto>>
    where TDto : class, IOrigin, IInnerProxy
    where TEntity : class, IOrigin, IInnerProxy
    where TStore : IDataServerStore
{
    protected readonly IStoreRepository<TEntity> _repository;
    protected readonly IServicer _umaker;

    public DeleteHandler(IServicer umaker, IStoreRepository<TStore, TEntity> repository)
    {
        _repository = repository;
        _umaker = umaker;
    }

    public async Task<Command<TDto>> Handle(
        Delete<TStore, TEntity, TDto> request,
        CancellationToken cancellationToken
    )
    {
        return await Task.Run(
            async () =>
            {
                if (!request.Result.IsValid)
                    return request;

                try
                {
                    if (request.Keys != null)
                        request.Entity = await _repository.Delete(request.Keys);
                    else if (request.Contract != null)
                    {
                        if (request.Predicate == null)
                            request.Entity = _repository.DeleteBy(request.Contract);
                        else
                            request.Entity = _repository.DeleteBy(
                                request.Contract,
                                request.Predicate
                            );
                    }
                    if (request.Entity == null)
                        throw new Exception(
                            $"{GetType().Name} for entity"
                                + $" {typeof(TEntity).Name} unable delete source"
                        );

                    _ = _umaker
                        .Publish(new Deleted<TStore, TEntity, TDto>(request))
                        .ConfigureAwait(false);
                    ;
                }
                catch (Exception ex)
                {
                    request.Result.Errors.Add(new ValidationFailure(string.Empty, ex.Message));
                    this.Failure<Applog>(ex.Message, request.ErrorMessages, ex);
                }

                return request;
            },
            cancellationToken
        );
    }
}
