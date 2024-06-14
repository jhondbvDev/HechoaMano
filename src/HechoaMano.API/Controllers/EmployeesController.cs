using HechoaMano.Application.Employees.Commands.UploadEmployees;
using HechoaMano.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController(ISender mediator) : ControllerBase
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _mediator.Send(new GetEmployeesQuery());

            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadEmployees(IFormFile file)
        {
            var command = new UploadEmployeesCommand(file);
            await _mediator.Send(command);

            return Created();
        }
    }
}
