using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControl
{
    public class GetInventoryControlQueryHandler(IInventoryRepository repository) : IRequestHandler<GetInventoryControlQuery, DetailedInventoryResult>
    {
        private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<DetailedInventoryResult> Handle(GetInventoryControlQuery request, CancellationToken cancellationToken)
        {
            var inventoryControl = await _repository.GetInventoryControlAsync(request.ControlId);
            return inventoryControl.Adapt<DetailedInventoryResult>();
        }
    }
}
