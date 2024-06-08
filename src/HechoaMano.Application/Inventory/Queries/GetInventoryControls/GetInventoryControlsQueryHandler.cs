using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControls;

public class GetInventoryControlsQueryHandler : IRequestHandler<GetInventoryControlsQuery, List<InventoryResult>>
{
    public Task<List<InventoryResult>> Handle(GetInventoryControlsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
