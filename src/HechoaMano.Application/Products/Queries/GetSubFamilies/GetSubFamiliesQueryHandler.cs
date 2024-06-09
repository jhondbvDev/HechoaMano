using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSubFamilies;

public class GetSubFamiliesQueryHandler(IProductRepository repository) : IRequestHandler<GetSubFamiliesQuery, List<SubFamilyResult>>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<SubFamilyResult>> Handle(GetSubFamiliesQuery request, CancellationToken cancellationToken)
    {
        var subFamilies = await _repository.GetAllSubFamiliesAsync();
        return subFamilies.ConvertAll(s => s.Adapt<SubFamilyResult>());
    }
}