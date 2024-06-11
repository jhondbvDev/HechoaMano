using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Entities;

namespace HechoaMano.Domain.Inventory.Aggregates;

public class EmployeeOrder : AggregateRoot<Guid>
{
    private readonly List<OrderDetail> _details = [];

    public UserId EmployeeId { get; private set; }
    public IReadOnlyList<OrderDetail> Details => _details.AsReadOnly();
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private EmployeeOrder(
        Guid id,
        UserId employeeId,
        List<OrderDetail> details,
        decimal totalPrice,
        DateTime createdDate) : base(id)
    {
        _details = details;
        EmployeeId = employeeId;
        TotalPrice = totalPrice;
        CreatedDate = createdDate;
    }

    public static EmployeeOrder Create(
        UserId employeeId,
        List<OrderDetail> details,
        decimal totalPrice)
    {
        return new(Guid.NewGuid(), employeeId, details, totalPrice, DateTime.Now);
    }
}