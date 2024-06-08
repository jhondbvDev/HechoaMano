using HechoaMano.Domain.Primitives.Abstractions;

namespace HechoaMano.Domain.Common.Models;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id), IAggregateRoot
{
    private readonly List<DomainEvent> _domainEvents = [];
    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
