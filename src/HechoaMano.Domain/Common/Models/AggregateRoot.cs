using HechoaMano.Domain.Primitives.Abstractions;

namespace HechoaMano.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
{
    private readonly List<DomainEvent> _domainEvents = [];
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public AggregateRoot()
    {
        
    }

    public AggregateRoot(TId id) : base(id)
    {

    }

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() =>  _domainEvents.Clear();
}
