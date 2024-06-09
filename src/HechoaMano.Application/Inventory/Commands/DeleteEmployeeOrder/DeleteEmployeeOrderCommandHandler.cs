using HechoaMano.Application.Inventory.Abstractions;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;

public class DeleteEmployeeOrderCommandHandler(IInventoryRepository repository) : IRequestHandler<DeleteEmployeeOrderCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Handle(DeleteEmployeeOrderCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteEmployeeOrderAsync(request.OrderId);
    }
}
