namespace HechoaMano.Application.Authentication.Abstractions;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string name);
}
