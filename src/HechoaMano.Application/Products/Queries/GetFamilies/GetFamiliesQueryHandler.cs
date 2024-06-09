using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetProducts;

public class GetFamiliesQueryHandler(IProductRepository repository) : IRequestHandler<GetFamiliesQuery, List<FamilyResult>>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<FamilyResult>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
    {
        var families = await _repository.GetAllFamiliesAsync();
        return families.ConvertAll(f => f.Adapt<FamilyResult>());
    }
}
