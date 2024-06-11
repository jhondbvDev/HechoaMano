namespace HechoaMano.Application.Inventory.Common;

public record DetailedInventoryResult(Guid ControlId, List<InventoryDetailResult> Details);