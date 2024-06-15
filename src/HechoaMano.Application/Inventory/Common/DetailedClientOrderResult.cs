namespace HechoaMano.Application.Inventory.Common;

public record DetailedClientOrderResult(Guid Id, string ClientName, string ShopName, string City, decimal Discount, List<OrderDetailResult> Details, decimal TotalPrice);
