using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControls;

public class GetInventoryControlsQueryHandler(IInventoryRepository repository) : IRequestHandler<GetInventoryControlsQuery, List<InventoryResult>>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<InventoryResult>> Handle(GetInventoryControlsQuery request, CancellationToken cancellationToken)
    {
        var inventoryControls = await _repository.GetAllInventoryControlsAsync();
        return inventoryControls.ConvertAll(i => i.Adapt<InventoryResult>());
    }
}
