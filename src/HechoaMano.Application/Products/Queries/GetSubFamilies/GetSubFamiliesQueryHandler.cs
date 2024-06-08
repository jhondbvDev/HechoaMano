using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSubFamilies;

public class GetSubFamiliesQueryHandler(IProductRepository productRepository) : IRequestHandler<GetSubFamiliesQuery, List<SubFamilyResult>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<SubFamilyResult>> Handle(GetSubFamiliesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}