using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Domain.Clients;
using MediatR;

namespace HechoaMano.Application.Clients.Commands.UploadClients;

public class UploadClientsCommandHandler(
    IClientRepository repository, 
    IFileDataExtractionService fileDataExtractionService,
    IUnitOfWork unitOfWork) : IRequestHandler<UploadClientsCommand>
{
    private readonly IClientRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IFileDataExtractionService _fileDataExtractionService = fileDataExtractionService ?? throw new ArgumentNullException(nameof(fileDataExtractionService));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(UploadClientsCommand request, CancellationToken cancellationToken)
    {
        if (!_fileDataExtractionService.ExtractClientsFromFile(request.File, out List<Client> clients))
        {
            throw new FileValidationException();
        }

        if (clients.Count == 0)
        {
            throw new FileWithNoRecordsException();
        }

        await _repository.CreateRangeAsync(clients);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
