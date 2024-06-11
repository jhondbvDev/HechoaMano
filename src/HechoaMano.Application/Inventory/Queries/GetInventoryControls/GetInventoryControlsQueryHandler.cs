using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControls;

public class GetInventoryControlsQueryHandler(
    IInventoryRepository inventoryRepository,
    IEmployeeRepository employeeRepository) : IRequestHandler<GetInventoryControlsQuery, List<InventoryResult>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

    public async Task<List<InventoryResult>> Handle(GetInventoryControlsQuery request, CancellationToken cancellationToken)
    {
        var inventoryControls = await _inventoryRepository.GetAllInventoryControlsAsync();

        //TODO: Get employee name per control

        return inventoryControls.ConvertAll(i => i.Adapt<InventoryResult>());
    }
}
