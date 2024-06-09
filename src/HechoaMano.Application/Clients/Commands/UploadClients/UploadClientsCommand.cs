using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Clients.Commands.UploadClients;

public record UploadClientsCommand(IFormFile File) : IRequest;
