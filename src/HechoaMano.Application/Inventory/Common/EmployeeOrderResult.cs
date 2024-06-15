namespace HechoaMano.Application.Inventory.Common;

public record EmployeeOrderResult(Guid Id, string EmployeeName, decimal TotalPrice, DateTime CreatedDate);
