namespace HechoaMano.Application.Products.Common;

public record ProductResult(
    Guid Id,
    string Name,
    string FamilyName,
    string SubFamilyName,
    string RegionName,
    string? FamilyTypeName,
    string SizeName,
    decimal SellPrice,
    decimal BuyPrice);