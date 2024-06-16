using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;

public class DeleteEmployeeOrderCommandHandler(IInventoryRepository repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteEmployeeOrderCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IUnitOfWork _unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));

    public async Task Handle(DeleteEmployeeOrderCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteEmployeeOrderAsync(request.OrderId);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
