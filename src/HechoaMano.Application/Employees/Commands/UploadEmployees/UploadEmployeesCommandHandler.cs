using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Employees;
using MediatR;
using System.Linq;

namespace HechoaMano.Application.Employees.Commands.UploadEmployees;

public class UploadEmployeesCommandHandler(
    IEmployeeRepository repository, 
    IFileDataExtractionService fileDataExtractionService,
    IUnitOfWork unitOfWork) : IRequestHandler<UploadEmployeesCommand>
{
    private readonly IEmployeeRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IFileDataExtractionService _fileDataExtractionService = fileDataExtractionService ?? throw new ArgumentNullException(nameof(fileDataExtractionService));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(UploadEmployeesCommand request, CancellationToken cancellationToken)
    {
        if (!_fileDataExtractionService.ExtractEmployeesFromFile(request.File, out List<Employee> employees))
        {
            throw new FileValidationException();
        }

        if (employees.Count == 0)
        {
            throw new FileWithNoRecordsException();
        }

        await CreateOrUpdateEmployees(employees);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }

    private async Task CreateOrUpdateEmployees(List<Employee> employees)
    {
        List<Employee> employeesForUpdate = [];

        foreach (var employee in employees)
        {
            var existingEmployee = await _repository.GetByDocumentId(employee.DocumentId);

            if (existingEmployee != null)
            {
                existingEmployee = Employee.Create(
                    existingEmployee.Id,
                    employee.Name,
                    existingEmployee.DocumentId,
                    existingEmployee.CreatedDate
                );

                employeesForUpdate.Add(existingEmployee);
            }
        }

        if (employeesForUpdate.Count > 0)
        {
            var employeesForUpdateDocumentIds = employeesForUpdate.Select(x => x.DocumentId);
            var employeesForCreate = employees.Where(e => !employeesForUpdateDocumentIds.Contains(e.DocumentId)).ToList();

            _repository.UpdateRange(employeesForUpdate);
            await _repository.CreateRangeAsync(employeesForCreate);
        }
        else
        {
            await _repository.CreateRangeAsync(employees);
        }
    }
}
