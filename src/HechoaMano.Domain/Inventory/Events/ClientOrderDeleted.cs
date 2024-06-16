using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Inventory.Aggregates;

namespace HechoaMano.Domain.Inventory.Events;

public record ClientOrderDeleted(ClientOrder Order) : DomainEvent;
