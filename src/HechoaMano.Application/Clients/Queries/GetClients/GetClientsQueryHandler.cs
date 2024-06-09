using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Clients.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Clients.Queries.GetClients;

public class GetClientsQueryHandler(IClientRepository repository) : IRequestHandler<GetClientsQuery, List<ClientResult>>
{
    private readonly IClientRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<ClientResult>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _repository.GetAllAsync();
        return clients.ConvertAll(c => c.Adapt<ClientResult>());
    }
}
