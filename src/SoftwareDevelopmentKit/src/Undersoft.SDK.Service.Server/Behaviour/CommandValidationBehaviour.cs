using FluentValidation;
using MediatR;

namespace Undersoft.SDK.Service.Server.Behaviour
{
    public class CommandValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TResponse>> _validators;

        public CommandValidationBehaviour(IEnumerable<IValidator<TResponse>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                (await Task.WhenAll(_validators
                              .Select(v => v
                              .ValidateAsync(context, cancellationToken))))
                                 .SelectMany(r => r.Errors)
                                 .ForEach(f => request.Result.Errors.Add(f));
            }

            return await next();
        }
    }
}