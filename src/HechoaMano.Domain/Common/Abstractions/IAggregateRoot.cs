using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Primitives.Abstractions;

public interface IAggregateRoot
{
    IReadOnlyList<DomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}