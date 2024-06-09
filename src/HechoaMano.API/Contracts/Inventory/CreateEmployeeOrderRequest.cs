using HechoaMano.API.Contracts.Inventory.Common;

namespace HechoaMano.API.Contracts.Inventory;

public record CreateEmployeeOrderRequest(Guid EmployeeId, List<OrderDetail> Details, decimal TotalPrice);