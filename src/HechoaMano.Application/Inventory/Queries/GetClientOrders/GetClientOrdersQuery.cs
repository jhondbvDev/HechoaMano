using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrders;

public record GetClientOrdersQuery : IRequest<List<ClientOrderResult>>;
