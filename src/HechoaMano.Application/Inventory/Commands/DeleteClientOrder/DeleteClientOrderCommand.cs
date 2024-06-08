using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteClientOrder;

public record DeleteClientOrderCommand(Guid OrderId) : IRequest;
