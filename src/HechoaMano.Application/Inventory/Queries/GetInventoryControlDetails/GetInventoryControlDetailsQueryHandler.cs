using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControlDetails
{
    public class GetInventoryControlDetailsQueryHandler : IRequestHandler<GetInventoryControlDetailsQuery, DetailedInventoryResult>
    {
        public Task<DetailedInventoryResult> Handle(GetInventoryControlDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
