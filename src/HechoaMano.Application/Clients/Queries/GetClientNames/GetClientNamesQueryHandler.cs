using HechoaMano.Application.Clients.Common;
using MediatR;

namespace HechoaMano.Application.Clients.Queries.GetClientNames;

public class GetClientNamesQueryHandler : IRequestHandler<GetClientNamesQuery, List<ClientNamesResult>>
{
    public Task<List<ClientNamesResult>> Handle(GetClientNamesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
