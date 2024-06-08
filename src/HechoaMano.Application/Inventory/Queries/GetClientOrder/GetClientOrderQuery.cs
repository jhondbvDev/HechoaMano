using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrder;

public record GetClientOrderQuery(Guid OrderId) : IRequest<DetailedClientOrderResult>;
