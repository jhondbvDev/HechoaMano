using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public sealed class Size : Entity<Guid>
{
    public string Name { get; }
    private Size(Guid id, string name) : base(id) => Name = name;

    public static Size Create(Guid id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new Size(id, value);
    }
}
