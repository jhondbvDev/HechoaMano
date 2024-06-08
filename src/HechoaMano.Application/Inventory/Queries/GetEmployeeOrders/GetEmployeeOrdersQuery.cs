using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrders;

public record GetEmployeeOrdersQuery : IRequest<List<EmployeeOrderResult>>;
