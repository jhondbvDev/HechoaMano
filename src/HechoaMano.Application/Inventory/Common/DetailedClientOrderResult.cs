namespace HechoaMano.Application.Inventory.Common;

public record DetailedClientOrderResult(
    Guid Id, 
    string ClientName, 
    string ShopName,
    string City, 
    List<OrderDetailResult> Details, 
    decimal Subtotal,
    decimal CalculetedDiscount,   
    decimal TotalPrice);
