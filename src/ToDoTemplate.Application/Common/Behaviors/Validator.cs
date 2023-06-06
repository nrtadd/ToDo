using FluentValidation;
using MediatR;

namespace ToDoTemplate.Application.Common.Behaviors
{
    public class Validator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public Validator(IEnumerable<IValidator<TRequest>> validators)
        {
            _validator = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var error = _validator.Select(valid => valid.Validate(context))
                    .SelectMany(request => request.Errors).ToList();
                if (error.Any())
                {
                    throw new ValidationException(error);
                }
            }
            return await next();
        }
    }
}
