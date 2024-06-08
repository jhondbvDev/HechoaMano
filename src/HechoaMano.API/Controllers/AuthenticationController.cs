using HechoaMano.Application.Authentication.Queries.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Authenticate()
    {
        var query = new AuthenticateQuery(Request.Headers.Authorization);
        var result = await mediator.Send(query);

        return Ok(result);
    }
}
