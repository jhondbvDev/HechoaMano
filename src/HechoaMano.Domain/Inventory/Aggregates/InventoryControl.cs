using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Entities;

namespace HechoaMano.Domain.Inventory.Aggregates;

public class InventoryControl : AggregateRoot<Guid>
{
    private readonly List<InventoryControlDetail> _details = [];

    public UserId EmployeeId { get; private set; }
    public IReadOnlyList<InventoryControlDetail> Details => _details.AsReadOnly();
    public DateTime CreatedDate { get; private set; }

    private InventoryControl(
        Guid id,
        UserId employeeId,
        List<InventoryControlDetail> details,
        DateTime createdDate) : base(id)
    {
        _details = details;
        EmployeeId = employeeId;
        CreatedDate = createdDate;
    }

    public static InventoryControl Create(
        UserId employeeId,
        List<InventoryControlDetail> details)
    {
        return new(Guid.NewGuid(), employeeId, details, DateTime.Now);
    }
}