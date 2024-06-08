using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControlDetails;

public record GetInventoryControlDetailsQuery(Guid ControlId) : IRequest<DetailedInventoryResult>;