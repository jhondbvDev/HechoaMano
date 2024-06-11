using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public sealed class Family : Entity<Guid>
{
    public string Name { get; private set; }

    private Family(Guid id, string name) : base(id) => Name = name;

    public static Family Create(Guid id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new Family(id, value);
    }
}
