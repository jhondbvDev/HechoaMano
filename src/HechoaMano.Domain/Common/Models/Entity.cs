namespace HechoaMano.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    public TId Id { get; private init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Entity()
   {

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Entity(TId id)
    {
        Id = id;
    }

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