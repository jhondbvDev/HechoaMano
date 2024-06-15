namespace HechoaMano.Application.Inventory.Common;

public record DetailedEmployeeOrderResult(Guid Id, string EmployeeName, List<OrderDetailResult> Details, decimal TotalPrice);
