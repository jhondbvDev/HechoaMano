using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Domain.Primitives
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;
        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}
