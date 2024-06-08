using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetInventoryControls;

public record GetInventoryControlsQuery : IRequest<List<InventoryResult>>;
