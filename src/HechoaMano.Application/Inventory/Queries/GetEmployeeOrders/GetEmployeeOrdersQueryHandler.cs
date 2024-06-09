using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;

public class GetEmployeeOrdersQueryHandler(IInventoryRepository repository) : IRequestHandler<GetEmployeeOrdersQuery, List<EmployeeOrderResult>>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<EmployeeOrderResult>> Handle(GetEmployeeOrdersQuery request, CancellationToken cancellationToken)
    {
        var employeeOrders = await _repository.GetAllEmployeeOrdersAsync();
        return employeeOrders.ConvertAll(e => e.Adapt<EmployeeOrderResult>());
    }
}
