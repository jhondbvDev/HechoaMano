using MediatR;

namespace HechoaMano.Domain.Common.Models;

public record DomainEvent(Guid Id) : INotification;
