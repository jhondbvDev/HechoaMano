namespace HechoaMano.Application.Inventory.Common;

public record DetailedEmployeeOrderResult(Guid OrderId, string EmployeeName, List<OrderDetailResult> Details, decimal TotalPrice);
