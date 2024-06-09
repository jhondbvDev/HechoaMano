using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetRegions;

public class GetRegionsQueryHandler(IProductRepository repository) : IRequestHandler<GetRegionsQuery, List<RegionResult>>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<RegionResult>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await _repository.GetAllRegionsAsync();
        return regions.ConvertAll(r => r.Adapt<RegionResult>());
    }
}
