namespace HechoaMano.Application.Inventory.Common;

//TODO: Details are pending
public record DetailedClientOrderResult(Guid OrderId, string ClientName, string ShopName, string City, decimal Discount, decimal TotalPrice);
