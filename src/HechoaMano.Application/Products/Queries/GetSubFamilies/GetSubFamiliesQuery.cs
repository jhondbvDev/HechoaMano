using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetSubFamilies;

public record GetSubFamiliesQuery : IRequest<List<SubFamilyResult>>;