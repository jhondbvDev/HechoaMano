using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateClientOrder;

public class CreateClientOrderCommandHandler(
    IInventoryRepository repository, 
    IUnitOfWork unitOfWork, 
    IProductRepository productRepository) : IRequestHandler<CreateClientOrderCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

    public async Task Handle(CreateClientOrderCommand request, CancellationToken cancellationToken)
    {
        await ValidateProductStocksAsync(request);

        var clientOrder = ClientOrder.Create(
            UserId.Create(request.ClientId),
            request.Details.ConvertAll(d =>
                OrderDetail.Create(
                    ProductId.Create(d.ProductId),
                    d.Quantity,
                    d.Price
                )
            ),
            request.TotalPrice
        );

        await _repository.AddClientOrderAsync(clientOrder);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }

    private async Task ValidateProductStocksAsync(CreateClientOrderCommand request)
    {
        List<StockErrorData> failedProductIds = [];

        foreach (var detail in request.Details)
        {
            var product = await _productRepository.GetProductAsync(ProductId.Create(detail.ProductId))
                ?? throw new RecordNotFoundException(detail.ProductId.ToString()); ;

            if (product.ProductStock.Value < detail.Quantity)
            {
                failedProductIds.Add(new(detail.ProductId, product.Name));
            }
        }

        if (failedProductIds.Count > 0)
        {
            throw new InsufficientStockException(failedProductIds);
        }
    }
}
