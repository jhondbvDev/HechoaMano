using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Employees.Commands.UploadEmployees;

public record UploadEmployeesCommand(IFormFile File) : IRequest;

