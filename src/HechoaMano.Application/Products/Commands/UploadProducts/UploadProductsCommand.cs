using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Products.Commands.UploadProducts;

public record UploadProductsCommand(IFormFile File) : IRequest;
