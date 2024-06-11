using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using HechoaMano.Application.Products.Abstractions;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControl
{
    public class GetInventoryControlQueryHandler(
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository) : IRequestHandler<GetInventoryControlQuery, DetailedInventoryResult>
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));

        public async Task<DetailedInventoryResult> Handle(GetInventoryControlQuery request, CancellationToken cancellationToken)
        {
            var inventoryControl = await _inventoryRepository.GetInventoryControlAsync(request.ControlId);

            //TODO: Get product name per detail

            return inventoryControl.Adapt<DetailedInventoryResult>();
        }
    }
}
