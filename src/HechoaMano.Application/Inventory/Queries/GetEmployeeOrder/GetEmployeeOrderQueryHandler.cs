using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;

public class GetEmployeeOrderQueryHandler(IInventoryRepository repository) : IRequestHandler<GetEmployeeOrderQuery, DetailedEmployeeOrderResult>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<DetailedEmployeeOrderResult> Handle(GetEmployeeOrderQuery request, CancellationToken cancellationToken)
    {
        var employeeOrder = await _repository.GetEmployeeOrderAsync(request.OrderId);
        return employeeOrder.Adapt<DetailedEmployeeOrderResult>();
    }
}
