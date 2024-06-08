using HechoaMano.Application.Employees.Common;
using MediatR;

namespace HechoaMano.Application.Employees.Queries.GetEmployees;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeResult>>
{
    public Task<List<EmployeeResult>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
