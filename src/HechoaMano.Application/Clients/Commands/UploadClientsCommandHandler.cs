using MediatR;

namespace HechoaMano.Application.Clients.Commands;

public class UploadClientsCommandHandler : IRequestHandler<UploadClientsCommand>
{
    public Task Handle(UploadClientsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
