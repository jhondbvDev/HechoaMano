using HechoaMano.Application.Employees.Commands;
using HechoaMano.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await mediator.Send(new GetEmployeesQuery());

            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadEmployees(IFormFile file)
        {
            var command = new UploadEmployeesCommand(file);
            await mediator.Send(command);

            return Created();
        }
    }
}
