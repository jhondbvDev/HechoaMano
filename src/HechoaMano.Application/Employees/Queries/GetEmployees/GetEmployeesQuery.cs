using HechoaMano.Application.Employees.Common;
using MediatR;

namespace HechoaMano.Application.Employees.Queries.GetEmployees;

public record GetEmployeesQuery : IRequest<List<EmployeeResult>>;
