using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public class FamilyType : Entity<Guid>
{
    public string Name { get; private set; }
    private readonly List<Product> _products = [];
    public virtual IReadOnlyList<Product> Products => _products.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FamilyType()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private FamilyType(Guid id, string name, List<Product> products) : base(id)
    {
        Name = name;
        _products = products;
    }

    public static FamilyType Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new FamilyType(Guid.NewGuid(), name, []);
    }

    public static FamilyType Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new FamilyType(id, name, []);
    }

    public static FamilyType Create(Guid id, string value, List<Product> products)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new FamilyType(id, value, products);
    }
}