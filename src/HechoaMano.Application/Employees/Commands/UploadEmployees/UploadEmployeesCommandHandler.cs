using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Domain.Employees;
using MediatR;

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

        await _repository.CreateRangeAsync(employees);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
