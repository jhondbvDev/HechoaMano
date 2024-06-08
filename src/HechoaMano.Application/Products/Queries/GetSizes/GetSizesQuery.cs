using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSizes;

public record GetSizesQuery : IRequest<List<SizeResult>>;
