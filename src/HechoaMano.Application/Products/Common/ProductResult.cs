namespace HechoaMano.Application.Products.Common;

public record ProductResult(
    Guid Id,
    string Name,
    string Family,
    string? SubFamily,
    string Region,
    string? FamilyType,
    string? Size,
    int Stock,
    decimal SellPrice,
    decimal BuyPrice);