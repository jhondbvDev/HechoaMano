using HechoaMano.Application.Inventory.Commands.DeleteClientOrder;
using HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;
using HechoaMano.Application.Inventory.Queries.GetClientOrder;
using HechoaMano.Application.Inventory.Queries.GetClientOrders;
using HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;
using HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;
using HechoaMano.Application.Inventory.Queries.GetInventoryControlDetails;
using HechoaMano.Application.Inventory.Queries.GetInventoryControls;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(ISender mediator) : ControllerBase
    {
        [HttpGet("controls")]
        public async Task<IActionResult> GetInventoryControls() 
        {
            var result = await mediator.Send(new GetInventoryControlsQuery());

            return Ok(result);
        }

        [HttpGet("controls/{controlId}")]
        public async Task<IActionResult> GetInventoryControlDetails(Guid controlId)
        {
            var query = new GetInventoryControlDetailsQuery(controlId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("client/orders")]
        public async Task<IActionResult> GetClientOrders()
        {
            var result = await mediator.Send(new GetClientOrdersQuery());

            return Ok(result);
        }

        [HttpGet("client/orders/{orderId}")]
        public async Task<IActionResult> GetClientOrder(Guid orderId)
        {
            var query = new GetClientOrderQuery(orderId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("client/orders/{orderId}")]
        public async Task<IActionResult> DeleteClientOrder(Guid orderId)
        {
            var command = new DeleteClientOrderCommand(orderId);
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet("employee/orders")]
        public async Task<IActionResult> GetEmployeeOrders()
        {
            var result = await mediator.Send(new GetEmployeeOrdersQuery());

            return Ok(result);
        }

        [HttpGet("employee/orders/{orderId}")]
        public async Task<IActionResult> GetEmployeeOrder(Guid orderId)
        {
            var query = new GetEmployeeOrderQuery(orderId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("employee/orders/{orderId}")]
        public async Task<IActionResult> DeleteEmployeeOrder(Guid orderId)
        {
            var command = new DeleteEmployeeOrderCommand(orderId);
            await mediator.Send(command);

            return Ok();
        }
    }
}
