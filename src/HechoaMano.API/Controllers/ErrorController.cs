using HechoaMano.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace HechoaMano.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error() 
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if(exception is BusinessValidationException validationException) 
            {
                var modelStateDictionary = new ModelStateDictionary();

                foreach (var error in validationException.Errors) 
                {
                    modelStateDictionary.AddModelError(error.ErrorCode, error.ErrorMessage);
                }

                return ValidationProblem(modelStateDictionary);
            }

            //TODO: Think about a better way to handle this to preserve maintainability
            if (exception is InsufficientStockException insufficientStockException)
            {
                return Problem(
                    statusCode: insufficientStockException.StatusCode, 
                    title: insufficientStockException.ErrorMessage, 
                    detail: JsonConvert.SerializeObject(insufficientStockException.FailedProducts));
            }

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => (serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error has ocurred"),
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
