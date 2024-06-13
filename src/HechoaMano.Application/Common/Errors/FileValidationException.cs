using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors
{
    public class FileValidationException : Exception, IServiceException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage => "The file does not contain the expected column format.";
    }
}
