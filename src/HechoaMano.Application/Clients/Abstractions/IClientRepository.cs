using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Common.ValueObjects;

namespace HechoaMano.Application.Clients.Abstractions;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task<Client?> GetAsync(UserId id);
    Task CreateRangeAsync(List<Client> clients);
    void UpdateRange(List<Client> clients);
}
