using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors;

public class InvalidCrendentialsException : Exception, IServiceException
{
    public int StatusCode => StatusCodes.Status401Unauthorized;

    public string ErrorMessage => "The provided user credentials are not valid.";
}
