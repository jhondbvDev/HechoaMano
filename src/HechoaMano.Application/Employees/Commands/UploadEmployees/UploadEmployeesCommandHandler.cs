using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Domain.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Employees.Commands.UploadEmployees;

public class UploadEmployeesCommandHandler(IEmployeeRepository repository) : IRequestHandler<UploadEmployeesCommand>
{
    private readonly IEmployeeRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Handle(UploadEmployeesCommand request, CancellationToken cancellationToken)
    {
        var employees = ExtractEmployeesFromFile(request.File);

        await _repository.CreateRangeAsync(employees);
    }

    //TODO: Implement extraction from Excel file into employee list
    private static List<Employee> ExtractEmployeesFromFile(IFormFile _)
    {
        return Enumerable.Empty<Employee>().ToList();
    }
}
