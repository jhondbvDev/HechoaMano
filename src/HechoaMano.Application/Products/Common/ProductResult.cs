namespace HechoaMano.Application.Products.Common;

public record ProductResult(
    Guid Id,
    string Name,
    string FamilyName,
    string SubFamilyName,
    string RegionName,
    string FamilyTypeName,
    string SizeName,
    int Stock,
    decimal SellPrice,
    decimal BuyPrice);