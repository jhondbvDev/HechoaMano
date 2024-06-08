using MediatR;

namespace HechoaMano.Application.Inventory.Commands.DeleteClientOrder;

public class DeleteClientOrderCommandHandler : IRequestHandler<DeleteClientOrderCommand>
{
    public Task Handle(DeleteClientOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
