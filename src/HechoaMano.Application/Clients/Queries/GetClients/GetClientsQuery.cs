using HechoaMano.Application.Clients.Common;
using MediatR;

namespace HechoaMano.Application.Clients.Queries.GetClients;

public record GetClientsQuery : IRequest<List<ClientResult>>;