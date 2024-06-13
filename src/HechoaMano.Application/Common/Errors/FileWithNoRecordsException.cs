using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors
{
    public sealed class FileWithNoRecordsException : Exception, IServiceException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage => "There are no records in the provided file.";
    }
}
