using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Products.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSizes;

public class GetSizesQueryHandler(IProductRepository repository) : IRequestHandler<GetSizesQuery, List<SizeResult>>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<SizeResult>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
    {
        var sizes = await _repository.GetAllSizesAsync();
        return sizes.ConvertAll(s => s.Adapt<SizeResult>());
    }
}
