using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;

public class GetEmployeeOrdersQueryHandler : IRequestHandler<GetEmployeeOrdersQuery, List<EmployeeOrderResult>>
{
    public Task<List<EmployeeOrderResult>> Handle(GetEmployeeOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
