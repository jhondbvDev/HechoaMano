using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrder
{
    public class GetClientOrderQueryHandler(IInventoryRepository repository) : IRequestHandler<GetClientOrderQuery, DetailedClientOrderResult>
    {
        private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<DetailedClientOrderResult> Handle(GetClientOrderQuery request, CancellationToken cancellationToken)
        {
            var clientOrder = await _repository.GetClientOrderAsync(request.OrderId);
            return clientOrder.Adapt<DetailedClientOrderResult>();
        }
    }
}
