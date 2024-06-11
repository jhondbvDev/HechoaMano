namespace HechoaMano.Application.Inventory.Common;

public record InventoryDetailResult(Guid ProductId, string ProductName, int CountedQuantity, int SystemQuantity);
