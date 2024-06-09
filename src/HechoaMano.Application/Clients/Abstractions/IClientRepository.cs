using HechoaMano.Domain.Clients;

namespace HechoaMano.Application.Clients.Abstractions;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task CreateRangeAsync(List<Client> clients);
    void UpdateRange(List<Client> clients);
}
