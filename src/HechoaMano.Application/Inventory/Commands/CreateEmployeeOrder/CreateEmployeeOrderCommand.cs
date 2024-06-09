using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateEmployeeOrder;

public record CreateEmployeeOrderCommand(Guid EmployeeId, List<OrderDetailCommand> Details, decimal TotalPrice) : IRequest;

public record OrderDetailCommand(Guid ProductId, int Quantity, decimal Price);