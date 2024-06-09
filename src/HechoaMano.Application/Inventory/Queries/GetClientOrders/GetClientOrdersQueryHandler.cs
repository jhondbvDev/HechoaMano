using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrders;

public class GetClientOrdersQueryHandler(IInventoryRepository repository) : IRequestHandler<GetClientOrdersQuery, List<ClientOrderResult>>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<ClientOrderResult>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
    {
        var clientOrders = await _repository.GetAllClientOrdersAsync();
        return clientOrders.ConvertAll(c => c.Adapt<ClientOrderResult>());
    }
}
