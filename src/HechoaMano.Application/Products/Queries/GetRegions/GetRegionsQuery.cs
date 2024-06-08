using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetRegions;

public record GetRegionsQuery() : IRequest<List<RegionResult>>;
