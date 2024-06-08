using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteEmployeeOrder;

public class DeleteEmployeeOrderCommandHandler : IRequestHandler<DeleteEmployeeOrderCommand>
{
    public Task Handle(DeleteEmployeeOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
