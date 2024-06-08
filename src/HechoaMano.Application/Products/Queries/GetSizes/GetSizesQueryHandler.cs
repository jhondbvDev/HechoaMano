using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSizes;

public class GetSizesQueryHandler(IProductRepository productRepository) : IRequestHandler<GetSizesQuery, List<SizeResult>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<SizeResult>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
