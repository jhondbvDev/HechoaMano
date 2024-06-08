using HechoaMano.Application.Clients.Common;
using MediatR;

namespace HechoaMano.Application.Clients.Queries.GetClientNames;

public record GetClientNamesQuery : IRequest<List<ClientNamesResult>>;
