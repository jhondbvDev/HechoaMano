using HechoaMano.Application.Inventory.Abstractions;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteClientOrder;

public class DeleteClientOrderCommandHandler(IInventoryRepository repository) : IRequestHandler<DeleteClientOrderCommand>
{
    private readonly IInventoryRepository _repository = repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Handle(DeleteClientOrderCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteClientOrderAsync(request.OrderId);
    }
}
