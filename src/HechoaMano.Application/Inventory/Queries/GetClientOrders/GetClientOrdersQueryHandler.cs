using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrders;

public class GetClientOrdersQueryHandler(
    IInventoryRepository inventoryRepository,
    IClientRepository clientRepository) : IRequestHandler<GetClientOrdersQuery, List<ClientOrderResult>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));

    public async Task<List<ClientOrderResult>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
    {
        var clientOrders = await _inventoryRepository.GetAllClientOrdersAsync();

        //TODO: Get client name per record

        return clientOrders.ConvertAll(c => c.Adapt<ClientOrderResult>());
    }
}
