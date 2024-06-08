namespace HechoaMano.Application.Common.Errors
{
    public interface IServiceException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}
