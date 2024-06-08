using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors
{
    public class BusinessValidationException(List<ValidationFailure> Errors) : Exception, IServiceException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage => "The provided input contains some error after validation. Please check.";

        public List<ValidationFailure> Errors { get; } = Errors;
    }
}
