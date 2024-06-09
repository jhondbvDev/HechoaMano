using HechoaMano.Application.Authentication.Abstractions;
using HechoaMano.Application.Authentication.Common;
using HechoaMano.Application.Common.Errors;
using MediatR;
using System.Text;

namespace HechoaMano.Application.Authentication.Queries.Authenticate;

public class AuthenticateQueryHandler(IJwtTokenGenerator tokenGenerator) : IRequestHandler<AuthenticateQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));

    private const string basicAuthorizationPrefix = "Basic";

    public async Task<AuthenticationResult> Handle(AuthenticateQuery query, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(query.AuthHeader) || !query.AuthHeader.StartsWith(basicAuthorizationPrefix))
        {
            throw new AuthorizationHeaderNotValidException();
        }

        if (!CheckIfValidUserAndPassword(query.AuthHeader))
        {
            throw new InvalidCrendentialsException();
        }

        var mvpUserGuid = Guid.NewGuid();
        var mvpUserName = "Usuario de Prueba";

        var token = _tokenGenerator.GenerateToken(mvpUserGuid, mvpUserName);

        var result = new AuthenticationResult(mvpUserName, token);

        return await Task.FromResult(result);
    }

    private static bool CheckIfValidUserAndPassword(string authHeader)
    {
        var encodedCredentials = authHeader[basicAuthorizationPrefix.Length..].Trim();

        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedCredentials));

        int seperatorIndex = usernamePassword.IndexOf(':');
        var username = usernamePassword[..seperatorIndex];
        var password = usernamePassword[(seperatorIndex + 1)..];

        return username == "Admin" && password == "Admin";
    }
}
