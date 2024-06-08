using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Entities;

namespace HechoaMano.Domain.Inventory.Aggregates;

public class ClientOrder : AggregateRoot<Guid>
{
    private readonly List<OrderDetail> _details = [];

    public UserId ClientId { get; }
    public IReadOnlyList<OrderDetail> Details => _details.AsReadOnly();
    public decimal TotalPrice { get; }
    public DateTime CreatedDate { get; }

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
        return new(Guid.NewGuid(), clientId, details, totalPrice, DateTime.Now);
    }
}
