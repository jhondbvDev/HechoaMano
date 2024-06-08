using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetRegions;

public class GetRegionsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetRegionsQuery, List<RegionResult>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<RegionResult>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
