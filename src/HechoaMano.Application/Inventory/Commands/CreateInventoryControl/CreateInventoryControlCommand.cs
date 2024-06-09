using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateInventoryControl;

public record CreateInventoryControlCommand(Guid EmployeeId, List<InventoryControlDetailCommand> Details) : IRequest;

public record InventoryControlDetailCommand(Guid ProductId, int CountedQuantity, int SystemQuantity);