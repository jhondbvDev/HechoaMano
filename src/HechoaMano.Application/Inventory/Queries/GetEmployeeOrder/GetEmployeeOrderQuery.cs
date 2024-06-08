using HechoaMano.Application.Inventory.Common;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;

public record GetEmployeeOrderQuery(Guid OrderId) : IRequest<DetailedEmployeeOrderResult>;
