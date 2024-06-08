using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Primitives.Abstractions
{
    public interface IAggregateRoot
    {
        ICollection<DomainEvent> DomainEvents { get; }
    }
}