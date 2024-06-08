using MediatR;

namespace HechoaMano.Application.Employees.Commands;

public class UploadEmployeesCommandHandler : IRequestHandler<UploadEmployeesCommand>
{
    public Task Handle(UploadEmployeesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
