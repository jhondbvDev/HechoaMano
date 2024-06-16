using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Inventory.Events;

namespace HechoaMano.Domain.Inventory.Aggregates;

public class EmployeeOrder : AggregateRoot<Guid>
{
    private readonly List<OrderDetail> _details = [];

    public UserId EmployeeId { get; private set; }
    public IReadOnlyList<OrderDetail> Details => _details.AsReadOnly();
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedDate { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EmployeeOrder()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
        var employeeOrder = new EmployeeOrder(
            Guid.NewGuid(),
            employeeId,
            details,
            totalPrice,
            DateTime.Now
        );

        employeeOrder.AddDomainEvent(new EmployeeOrderCreated(employeeOrder));

        return employeeOrder;
    }

    public void NotifyDelete()
    {
        AddDomainEvent(new EmployeeOrderDeleted(this));
    }
}