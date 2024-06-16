using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Errors
{
    public class InsufficientStockException(List<StockErrorData> failedProducts) : Exception, IServiceException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage => "One or more products do not have enough stock for the order to continue.";

        public List<StockErrorData> FailedProducts => failedProducts;
    }

    public record StockErrorData(Guid Id, string Name);
}
