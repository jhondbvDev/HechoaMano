using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public sealed class FamilyType : Entity<Guid>
{
    public string Name { get; private set; }

    private FamilyType(Guid id, string name) : base(id) => Name = name;

    public static FamilyType Create(Guid id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new FamilyType(id, value);
    }
}