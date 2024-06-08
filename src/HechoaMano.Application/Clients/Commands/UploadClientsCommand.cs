using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Clients.Commands;

public record UploadClientsCommand(IFormFile File) : IRequest;
