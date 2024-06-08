using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Employees.Commands;

public record UploadEmployeesCommand(IFormFile File) : IRequest;

