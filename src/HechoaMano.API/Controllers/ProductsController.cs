using HechoaMano.Application.Products.Common;
using HechoaMano.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    public class ProductsController :ControllerBase
    {
        private readonly ISender _mediator;
        public ProductsController(ISender mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

    }
}
