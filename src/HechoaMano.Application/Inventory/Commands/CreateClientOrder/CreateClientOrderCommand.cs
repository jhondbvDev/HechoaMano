using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateClientOrder;

public record CreateClientOrderCommand(Guid ClientId, List<OrderDetailCommand> Details, decimal TotalPrice) : IRequest;

public record OrderDetailCommand(Guid ProductId, int Quantity, decimal Price);