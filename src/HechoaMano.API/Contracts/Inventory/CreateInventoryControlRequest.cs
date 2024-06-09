namespace HechoaMano.API.Contracts.Inventory;

public record CreateInventoryControlRequest(Guid EmployeeId, List<InventoryControlDetail> Details);

public record InventoryControlDetail(Guid ProductId, int CountedQuantity, int SystemQuantity);