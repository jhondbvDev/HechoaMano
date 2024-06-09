namespace HechoaMano.Application.Inventory.Common;

public record ClientOrderResult(Guid OrderId, string ClientName, string ShopName, decimal TotalPrice, DateTime CreatedDate);