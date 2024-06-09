using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Domain.Clients;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Clients.Commands.UploadClients;

public class UploadClientsCommandHandler(IClientRepository repository) : IRequestHandler<UploadClientsCommand>
{
    private readonly IClientRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Handle(UploadClientsCommand request, CancellationToken cancellationToken)
    {
        var clients = ExtractClientsFromFile(request.File);

        await _repository.CreateRangeAsync(clients);
    }

    //TODO: Implement extraction from Excel file into client list
    private static List<Client> ExtractClientsFromFile(IFormFile _) 
    {
        return Enumerable.Empty<Client>().ToList();
    }
}
