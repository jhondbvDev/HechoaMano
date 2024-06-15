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
    private readonly IClientRepository _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));

    public async Task<List<ClientOrderResult>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
    {
        var clientOrders = await _inventoryRepository.GetAllClientOrdersAsync();

        List<ClientOrderResult> results = [];

        foreach (var clientOrder in clientOrders)
        {
            var client = await _clientRepository.GetAsync(clientOrder.ClientId);
            results.Add((clientOrder, client).Adapt<ClientOrderResult>());
        }

        return results;
    }
}
