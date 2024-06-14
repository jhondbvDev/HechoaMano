using HechoaMano.API.Contracts.Inventory;
using HechoaMano.Application.Inventory.Commands.CreateClientOrder;
using HechoaMano.Application.Inventory.Commands.CreateEmployeeOrder;
using HechoaMano.Application.Inventory.Commands.CreateInventoryControl;
using HechoaMano.Application.Inventory.Commands.DeleteClientOrder;
using HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;
using HechoaMano.Application.Inventory.Queries.GetClientOrder;
using HechoaMano.Application.Inventory.Queries.GetClientOrders;
using HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;
using HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;
using HechoaMano.Application.Inventory.Queries.GetInventoryControl;
using HechoaMano.Application.Inventory.Queries.GetInventoryControls;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HechoaMano.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController(ISender mediator) : ControllerBase
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("controls")]
        public async Task<IActionResult> GetInventoryControls() 
        {
            var result = await _mediator.Send(new GetInventoryControlsQuery());

            return Ok(result);
        }

        [HttpGet("controls/{controlId}")]
        public async Task<IActionResult> GetInventoryControl(Guid controlId)
        {
            var query = new GetInventoryControlQuery(controlId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("controls")]
        public async Task<IActionResult> CreateInventoryControl(CreateInventoryControlRequest payload)
        {
            var command = payload.Adapt<CreateInventoryControlCommand>();
            await _mediator.Send(command);

            return Created();
        }

        [HttpGet("client/orders")]
        public async Task<IActionResult> GetClientOrders()
        {
            var result = await _mediator.Send(new GetClientOrdersQuery());

            return Ok(result);
        }

        [HttpGet("client/orders/{orderId}")]
        public async Task<IActionResult> GetClientOrder(Guid orderId)
        {
            var query = new GetClientOrderQuery(orderId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("client/orders")]
        public async Task<IActionResult> CreateClientOrder(CreateClientOrderRequest payload)
        {
            var command = payload.Adapt<CreateClientOrderCommand>();
            await _mediator.Send(command);

            return Created();
        }

        [HttpDelete("client/orders/{orderId}")]
        public async Task<IActionResult> DeleteClientOrder(Guid orderId)
        {
            var command = new DeleteClientOrderCommand(orderId);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("employee/orders")]
        public async Task<IActionResult> GetEmployeeOrders()
        {
            var result = await _mediator.Send(new GetEmployeeOrdersQuery());

            return Ok(result);
        }

        [HttpGet("employee/orders/{orderId}")]
        public async Task<IActionResult> GetEmployeeOrder(Guid orderId)
        {
            var query = new GetEmployeeOrderQuery(orderId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("employee/orders")]
        public async Task<IActionResult> CreateEmployeeOrder(CreateEmployeeOrderRequest payload)
        {
            var command = payload.Adapt<CreateEmployeeOrderCommand>();
            await _mediator.Send(command);

            return Created();
        }

        [HttpDelete("employee/orders/{orderId}")]
        public async Task<IActionResult> DeleteEmployeeOrder(Guid orderId)
        {
            var command = new DeleteEmployeeOrderCommand(orderId);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
