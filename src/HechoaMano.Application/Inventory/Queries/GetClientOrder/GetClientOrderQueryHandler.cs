using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrder
{
    public class GetClientOrderQueryHandler : IRequestHandler<GetClientOrderQuery, DetailedClientOrderResult>
    {
        public Task<DetailedClientOrderResult> Handle(GetClientOrderQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
