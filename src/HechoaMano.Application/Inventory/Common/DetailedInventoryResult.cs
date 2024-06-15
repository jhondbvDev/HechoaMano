namespace HechoaMano.Application.Inventory.Common;

public record DetailedInventoryResult(Guid Id, List<InventoryDetailResult> Details);