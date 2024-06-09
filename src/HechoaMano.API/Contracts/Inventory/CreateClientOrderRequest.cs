using HechoaMano.API.Contracts.Inventory.Common;

namespace HechoaMano.API.Contracts.Inventory;

public record CreateClientOrderRequest(Guid ClientId, List<OrderDetail> Details, decimal TotalPrice);