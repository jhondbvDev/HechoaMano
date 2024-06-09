#pragma warning disable IDE0150 // Prefer 'null' check over type check

namespace HechoaMano.Domain.Common.Models;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>
{
    public TId Id { get; protected init; } = id;

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b)
    {
        return !Equals(a, b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        if (obj is not Entity<TId> entity)
        {
            return false;
        }
        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Id!.Equals(entity.Id);

    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }
}

#pragma warning restore IDE0150 // Prefer 'null' check over type check