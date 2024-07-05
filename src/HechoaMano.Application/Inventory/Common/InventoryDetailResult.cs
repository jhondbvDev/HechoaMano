namespace HechoaMano.Application.Inventory.Common;

public record InventoryDetailResult(
    Guid ProductId, 
    string ProductName,
    string ProductFamily,
    string? ProductSubFamily,
    string ProductRegion,
    string? ProductFamilyType,
    string? ProductSize,
    int CountedQuantity, 
    int SystemQuantity);
