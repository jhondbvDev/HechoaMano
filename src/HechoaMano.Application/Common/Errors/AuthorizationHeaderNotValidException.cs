using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors;

public class AuthorizationHeaderNotValidException : Exception, IServiceException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage => "Authorization header is empty or does not contain a valid token.";
}
