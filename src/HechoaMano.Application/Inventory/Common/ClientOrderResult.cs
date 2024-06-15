namespace HechoaMano.Application.Inventory.Common;

public record ClientOrderResult(Guid Id, string ClientName, string ShopName, decimal TotalPrice, DateTime CreatedDate);