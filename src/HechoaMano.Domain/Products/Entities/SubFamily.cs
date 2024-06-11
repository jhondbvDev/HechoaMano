using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;
public sealed class SubFamily : Entity<Guid>
{
    public string Name { get; private set; }

    private SubFamily(Guid id, string name) : base(id) => Name = name;

    public static SubFamily Create(Guid id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new SubFamily(id, value);
    }
}