using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;

public class GetEmployeeOrderQueryHandler : IRequestHandler<GetEmployeeOrderQuery, DetailedEmployeeOrderResult>
{
    public Task<DetailedEmployeeOrderResult> Handle(GetEmployeeOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
