using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors;

public class RecordNotFoundException : Exception, IServiceException
{
    public int StatusCode => StatusCodes.Status404NotFound;

    public string ErrorMessage => "The record you are trying to access or manipulate was not found.";
}
