using HechoaMano.Application.Common.Errors;
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
        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        public async Task<DetailedInventoryResult> Handle(GetInventoryControlQuery request, CancellationToken cancellationToken)
        {
            var inventoryControl = await _inventoryRepository.GetInventoryControlAsync(request.ControlId) ?? throw new RecordNotFoundException(request.ControlId.ToString());

            List<InventoryDetailResult> details = [];

            foreach (var item in inventoryControl.Details)
            {
                var product = await _productRepository.GetProductAsync(item.ProductId);
                details.Add((item,product).Adapt<InventoryDetailResult>());
            }

            return new(inventoryControl.Id, details);
        }
    }
}
