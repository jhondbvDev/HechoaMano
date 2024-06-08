using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrders;

public class GetClientOrdersQueryHandler : IRequestHandler<GetClientOrdersQuery, List<ClientOrderResult>>
{
    public Task<List<ClientOrderResult>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
