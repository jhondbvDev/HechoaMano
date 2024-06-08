using HechoaMano.Application.Clients.Common;
using MediatR;

namespace HechoaMano.Application.Clients.Queries.GetClients;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientResult>>
{
    public Task<List<ClientResult>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
