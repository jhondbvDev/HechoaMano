using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControl;

public record GetInventoryControlQuery(Guid ControlId) : IRequest<DetailedInventoryResult>;