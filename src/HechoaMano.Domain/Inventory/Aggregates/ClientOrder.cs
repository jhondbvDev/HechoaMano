using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Inventory.Events;

namespace HechoaMano.Domain.Inventory.Aggregates;

public class ClientOrder : AggregateRoot<Guid>
{
    private readonly List<OrderDetail> _details = [];

    public UserId ClientId { get; private set; }
    public IReadOnlyList<OrderDetail> Details => _details.AsReadOnly();
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedDate { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ClientOrder()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private ClientOrder(
        Guid id,
        UserId clientId,
        List<OrderDetail> details,
        decimal totalPrice,
        DateTime createdDate) : base(id)
    {
        _details = details;
        ClientId = clientId;
        TotalPrice = totalPrice;
        CreatedDate = createdDate;
    }

    public static ClientOrder Create(
        UserId clientId,
        List<OrderDetail> details,
        decimal totalPrice)
    {
        var clientOrder = new ClientOrder(
            Guid.NewGuid(),
            clientId,
            details,
            totalPrice,
            DateTime.Now
        );

        clientOrder.AddDomainEvent(new ClientOrderCreated(clientOrder));

        return clientOrder;
    }

    public void NotifyDelete()
    {
        AddDomainEvent(new ClientOrderDeleted(this));
    }
}