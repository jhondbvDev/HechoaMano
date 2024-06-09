using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Products.Commands.UploadProducts;

public class UploadProductsCommandHandler(IProductRepository repository) : IRequestHandler<UploadProductsCommand>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 

    public async Task Handle(UploadProductsCommand request, CancellationToken cancellationToken)
    {
        var products = ExtractProductsFromFile(request.File);

        await _repository.CreateProductsAsync(products);
    }

    //TODO: Implement extraction from Excel file into product list
    private static List<Product> ExtractProductsFromFile(IFormFile _)
    {
        return Enumerable.Empty<Product>().ToList();
    }
}
