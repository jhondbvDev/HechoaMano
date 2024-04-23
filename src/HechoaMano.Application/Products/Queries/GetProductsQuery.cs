using HechoaMano.Application.Products.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Products.Queries
{
    public record GetProductsQuery() : IRequest<List<ProductsResult>>;

}
