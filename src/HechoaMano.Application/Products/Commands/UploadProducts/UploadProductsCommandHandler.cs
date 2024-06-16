using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Products;
using MediatR;

namespace HechoaMano.Application.Products.Commands.UploadProducts;

public class UploadProductsCommandHandler(
    IProductRepository repository, 
    IFileDataExtractionService fileDataExtractionService,
    IUnitOfWork unitOfWork) : IRequestHandler<UploadProductsCommand>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IFileDataExtractionService _fileDataExtractionService = fileDataExtractionService ?? throw new ArgumentNullException(nameof(fileDataExtractionService));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(UploadProductsCommand request, CancellationToken cancellationToken)
    {
        if (!_fileDataExtractionService.ExtractProductsFromFile(request.File, out List<Product> products))
        {
            throw new FileValidationException();
        }

        if (products.Count == 0)
        {
            throw new FileWithNoRecordsException();
        }

        await CreateOrUpdateProduct(products);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }

    private async Task CreateOrUpdateProduct(List<Product> products)
    {
        List<Product> productsForUpdate = [];

        foreach (var product in products)
        {
            var existingProduct = await _repository.GetProductNoTrackingAsync(product.Id);

            if (existingProduct != null)
            {
                existingProduct = Product.Create(
                    existingProduct.Id,
                    product.Name,
                    product.FamilyTypeId,
                    product.FamilyId,
                    product.SubFamilyId,
                    product.SizeId,
                    product.RegionId,
                    existingProduct.ProductStock,
                    product.SellPrice,
                    product.BuyPrice,
                    existingProduct.CreatedDate
                );

                productsForUpdate.Add(existingProduct);
            }
        }

        if (productsForUpdate.Count > 0)
        {
            var productsForUpdateIds = productsForUpdate.Select(x => x.Id);
            var productsForCreate = products.Where(p => !productsForUpdateIds.Contains(p.Id)).ToList();

            _repository.UpdateProducts(productsForUpdate);
            await _repository.CreateProductsAsync(productsForCreate);
        }
        else
        {
            await _repository.CreateProductsAsync(products);
        }
    }
}
