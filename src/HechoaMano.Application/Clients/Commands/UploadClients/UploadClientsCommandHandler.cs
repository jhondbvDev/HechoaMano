using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Clients.ValueObjects;
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

        await CreateOrUpdateClients(clients);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }

    private async Task CreateOrUpdateClients(List<Client> clients)
    {
        List<Client> clientsForUpdate = [];

        foreach (var client in clients)
        {
            var existingClient = await _repository.GetByDocumentId(client.DocumentId);

            if (existingClient != null)
            {
                existingClient = Client.Create(
                    existingClient.Id,
                    client.Name,
                    existingClient.DocumentId,
                    ContactInformation.Create(
                        client.ContactInfo.Address,
                        client.ContactInfo.PhoneNumber,
                        client.ContactInfo.City
                    ),
                    client.ShopName,
                    client.Discount,
                    existingClient.CreatedDate
                );

                clientsForUpdate.Add(existingClient);
            }
        }

        if(clientsForUpdate.Count > 0)
        {
            var clientsForUpdateDocumentIds = clientsForUpdate.Select(c => c.DocumentId);
            var clientsForCreate = clients.Where(c => !clientsForUpdateDocumentIds.Contains(c.DocumentId)).ToList();

            _repository.UpdateRange(clientsForUpdate);
            await _repository.CreateRangeAsync(clientsForCreate);
        }
        else 
        {
            await _repository.CreateRangeAsync(clients);
        }
    }
}
