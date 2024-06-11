using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
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

        //TODO: Get employee name per record
        
        return employeeOrders.ConvertAll(e => e.Adapt<EmployeeOrderResult>());
    }
}
