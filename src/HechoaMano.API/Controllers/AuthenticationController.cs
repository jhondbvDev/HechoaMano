using HechoaMano.Application.Authentication.Queries.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthenticationController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    public async Task<IActionResult> Authenticate()
    {
        var query = new AuthenticateQuery(Request.Headers.Authorization);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
