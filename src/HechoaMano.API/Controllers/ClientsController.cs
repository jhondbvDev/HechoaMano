using HechoaMano.Application.Clients.Commands;
using HechoaMano.Application.Clients.Queries.GetClientNames;
using HechoaMano.Application.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClients() 
        {
            var result = await mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetClientNames() 
        {
            var result = await mediator.Send(new GetClientNamesQuery());

            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadClients(IFormFile file)
        {
            var command = new UploadClientsCommand(file);
            await mediator.Send(command);

            return Created();
        }
    }
}
