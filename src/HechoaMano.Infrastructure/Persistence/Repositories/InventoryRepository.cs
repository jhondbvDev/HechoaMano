using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Domain.Inventory.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence.Repositories;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #region InventoryControl
    public async Task<List<InventoryControl>> GetAllInventoryControlsAsync() => await _context.InventoryControls.AsNoTracking().ToListAsync();
    public async Task<InventoryControl?> GetInventoryControlAsync(Guid controlId) => 
        await _context.InventoryControls.AsNoTrackingWithIdentityResolution().Include(i => i.Details).SingleOrDefaultAsync(i => i.Id == controlId);
    public async Task AddInventoryControlAsync(InventoryControl record) => await _context.InventoryControls.AddAsync(record);
    #endregion

    #region ClientOrder
    public async Task<List<ClientOrder>> GetAllClientOrdersAsync() => await _context.ClientOrders.AsNoTracking().ToListAsync();
    public async Task<ClientOrder?> GetClientOrderAsync(Guid orderId) => 
        await _context.ClientOrders.AsNoTrackingWithIdentityResolution().Include(c => c.Details).SingleOrDefaultAsync(c => c.Id == orderId);
    public async Task AddClientOrderAsync(ClientOrder record) => await _context.ClientOrders.AddAsync(record);
    public async Task DeleteClientOrderAsync(Guid orderId)
    {
        var recordToDelete = await _context.ClientOrders.SingleOrDefaultAsync(c => c.Id == orderId) ?? throw new RecordNotFoundException(orderId.ToString());

        context.ClientOrders.Remove(recordToDelete);
        recordToDelete.NotifyDelete();
    }
    #endregion

    #region EmployeeOrder
    public async Task<List<EmployeeOrder>> GetAllEmployeeOrdersAsync() => await _context.EmployeeOrders.AsNoTracking().ToListAsync();
    public async Task<EmployeeOrder?> GetEmployeeOrderAsync(Guid orderId) =>
        await _context.EmployeeOrders.AsNoTrackingWithIdentityResolution().Include(e => e.Details).SingleOrDefaultAsync(e => e.Id == orderId);
    public async Task AddEmployeeOrderAsync(EmployeeOrder record) => await _context.EmployeeOrders.AddAsync(record);
    public async Task DeleteEmployeeOrderAsync(Guid orderId)
    {
        var recordToDelete = await _context.EmployeeOrders.SingleOrDefaultAsync(e => e.Id == orderId) ?? throw new RecordNotFoundException(orderId.ToString());

        context.EmployeeOrders.Remove(recordToDelete);
        recordToDelete.NotifyDelete();
    }
    #endregion
}