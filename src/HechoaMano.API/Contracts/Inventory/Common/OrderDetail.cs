namespace HechoaMano.API.Contracts.Inventory.Common;

public record OrderDetail(Guid ProductId, int Quantity, decimal Price);