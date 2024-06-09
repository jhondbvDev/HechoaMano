using HechoaMano.Application.Clients.Commands.UploadClients;
using HechoaMano.Application.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(ISender mediator) : ControllerBase
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        public async Task<IActionResult> GetClients() 
        {
            var result = await _mediator.Send(new GetClientsQuery());

            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadClients(IFormFile file)
        {
            var command = new UploadClientsCommand(file);
            await _mediator.Send(command);

            return Created();
        }
    }
}
