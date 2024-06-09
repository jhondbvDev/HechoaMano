namespace HechoaMano.Application.Inventory.Common;

public record EmployeeOrderResult(Guid OrderId, string EmployeeName, decimal TotalPrice, DateTime CreatedDate);
