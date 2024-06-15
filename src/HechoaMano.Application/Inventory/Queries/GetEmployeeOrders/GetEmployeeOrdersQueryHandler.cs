using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using HechoaMano.Domain.Inventory.Aggregates;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;

public class GetEmployeeOrdersQueryHandler(
    IInventoryRepository inventoryRepository,
    IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeOrdersQuery, List<EmployeeOrderResult>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

    public async Task<List<EmployeeOrderResult>> Handle(GetEmployeeOrdersQuery request, CancellationToken cancellationToken)
    {
        var employeeOrders = await _inventoryRepository.GetAllEmployeeOrdersAsync();

        List<EmployeeOrderResult> results = [];

        foreach (var employeeOrder in employeeOrders)
        {
            var client = await _employeeRepository.GetAsync(employeeOrder.EmployeeId);
            results.Add((employeeOrder, client).Adapt<EmployeeOrderResult>());
        }

        return results;
    }
}
