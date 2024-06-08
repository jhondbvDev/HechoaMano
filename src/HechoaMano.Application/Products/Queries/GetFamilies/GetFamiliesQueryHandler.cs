using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetProducts;

public class GetFamiliesQueryHandler(IProductRepository productRepository) : IRequestHandler<GetFamiliesQuery, List<FamilyResult>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<FamilyResult>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
