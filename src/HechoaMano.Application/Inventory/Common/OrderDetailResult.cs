namespace HechoaMano.Application.Inventory.Common;

public record OrderDetailResult(Guid ProductId, string ProductName, int Quantity, decimal Price);
