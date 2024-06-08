using HechoaMano.Application.Authentication.Common;
using MediatR;

namespace HechoaMano.Application.Authentication.Queries.Authenticate;

public record AuthenticateQuery(string? AuthHeader)  : IRequest<AuthenticationResult>;
