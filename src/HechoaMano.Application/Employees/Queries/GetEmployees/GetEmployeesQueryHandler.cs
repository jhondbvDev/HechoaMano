using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Application.Employees.Common;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Employees.Queries.GetEmployees;

public class GetEmployeesQueryHandler(IEmployeeRepository repository) : IRequestHandler<GetEmployeesQuery, List<EmployeeResult>>
{
    private readonly IEmployeeRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<List<EmployeeResult>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repository.GetAllAsync();

        return employees.ConvertAll(e => e.Adapt<EmployeeResult>());
    }
}
