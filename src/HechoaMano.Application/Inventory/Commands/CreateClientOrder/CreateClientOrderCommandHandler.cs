using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateClientOrder;

public class CreateClientOrderCommandHandler(IInventoryRepository repository) : IRequestHandler<CreateClientOrderCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Handle(CreateClientOrderCommand request, CancellationToken cancellationToken)
    {
        var clientOrder = ClientOrder.Create(
            UserId.Create(request.ClientId),
            request.Details.ConvertAll(d =>
                OrderDetail.Create(
                    ProductId.Create(d.ProductId),
                    d.Quantity,
                    d.Price
                )
            ),
            request.TotalPrice
        );

        await _repository.AddClientOrderAsync(clientOrder);
    }
}
