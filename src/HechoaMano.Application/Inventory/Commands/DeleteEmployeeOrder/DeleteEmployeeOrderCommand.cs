using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;

public record DeleteEmployeeOrderCommand(Guid OrderId) : IRequest;

