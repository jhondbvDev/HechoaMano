using FluentValidation;
using HechoaMano.Application.Common.Errors;
using MediatR;

namespace HechoaMano.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validator != null) 
            {
                var validationResults = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResults.IsValid)
                {
                    throw new BusinessValidationException(validationResults.Errors);
                }
            }

            return await next();
        }
    }
}
