namespace HechoaMano.Application.Inventory.Common;

public record OrderDetailResult(
    Guid ProductId, 
    string ProductName,
    string ProductFamily,
    string? ProductSubFamily,
    string ProductRegion,
    string? ProductFamilyType,
    string? ProductSize,
    int Quantity, 
    decimal Price);
