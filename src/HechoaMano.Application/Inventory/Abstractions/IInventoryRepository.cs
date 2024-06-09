using HechoaMano.Domain.Inventory.Aggregates;

namespace HechoaMano.Application.Inventory.Abstractions;

public interface IInventoryRepository
{
    #region InventoryControl
    Task<List<InventoryControl>> GetAllInventoryControlsAsync();
    Task<InventoryControl?> GetInventoryControlAsync(Guid controlId);
    Task AddInventoryControlAsync(InventoryControl record);
    #endregion

    #region ClientOrder
    Task<List<ClientOrder>> GetAllClientOrdersAsync();
    Task<ClientOrder?> GetClientOrderAsync(Guid orderId);
    Task AddClientOrderAsync(ClientOrder record);
    Task DeleteClientOrderAsync(Guid orderId);
    #endregion

    #region EmployeeOrder
    Task<List<EmployeeOrder>> GetAllEmployeeOrdersAsync();
    Task<EmployeeOrder?> GetEmployeeOrderAsync(Guid orderId);
    Task AddEmployeeOrderAsync(EmployeeOrder record);
    Task DeleteEmployeeOrderAsync(Guid orderId);
    #endregion
}
