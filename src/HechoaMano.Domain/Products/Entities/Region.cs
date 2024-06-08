using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public sealed class Region : Entity<Guid>
{
    public string Name { get; }
    private Region(Guid id, string name) : base(id) => Name = name;

    public static Region Create(Guid id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new Region(id, value);
    }
}
