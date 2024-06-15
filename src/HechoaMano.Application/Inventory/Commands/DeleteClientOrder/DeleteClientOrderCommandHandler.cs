using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteClientOrder;

public class DeleteClientOrderCommandHandler(IInventoryRepository repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteClientOrderCommand>
{
    private readonly IInventoryRepository _repository = repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IUnitOfWork _unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));

    public async Task Handle(DeleteClientOrderCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteClientOrderAsync(request.OrderId);

        //TODO: ask, should I revert the stock?

        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
