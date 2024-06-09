using HechoaMano.Application.Products.Commands.UploadProducts;
using HechoaMano.Application.Products.Queries.GetProducts;
using HechoaMano.Application.Products.Queries.GetRegions;
using HechoaMano.Application.Products.Queries.GetSizes;
using HechoaMano.Application.Products.Queries.GetSubFamilies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadProducts(IFormFile file)
    {
        var command = new UploadProductsCommand(file);
        await _mediator.Send(command);

        return Created();
    }

    [HttpGet("families")]
    public async Task<IActionResult> GetFamilies()
    {
        var families = await _mediator.Send(new GetFamiliesQuery());
        return Ok(families);
    }

    [HttpGet("subfamilies")]
    public async Task<IActionResult> GetSubFamilies()
    {
        var subFamilies = await _mediator.Send(new GetSubFamiliesQuery());
        return Ok(subFamilies);
    }

    [HttpGet("sizes")]
    public async Task<IActionResult> GetSizes()
    {
        var sizes = await _mediator.Send(new GetSizesQuery());
        return Ok(sizes);
    }

    [HttpGet("regions")]
    public async Task<IActionResult> GetRegions()
    {
        var regions = await _mediator.Send(new GetRegionsQuery());
        return Ok(regions);
    }
}
