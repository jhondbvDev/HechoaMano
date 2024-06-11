using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence.Repositories;

public class ClientRepository(ApplicationDbContext context) : IClientRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<List<Client>> GetAllAsync() => await _context.Clients.AsNoTracking().ToListAsync();
    public async Task<Client?> GetAsync(UserId id) => await _context.Clients.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
    public async Task CreateRangeAsync(List<Client> clients) => await _context.Clients.AddRangeAsync(clients);
    public void UpdateRange(List<Client> clients) => _context.UpdateRange(clients);
}
