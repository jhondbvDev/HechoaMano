using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, List<ProductResult>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<ProductResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll();
        return products.ConvertAll(p => p.Adapt<ProductResult>());
    }
}
