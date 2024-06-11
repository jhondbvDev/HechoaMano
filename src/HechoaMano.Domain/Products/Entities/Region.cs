using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public class Region : Entity<Guid>
{
    public string Name { get; private set; }
    private readonly List<Product> _products = [];
    public virtual IReadOnlyList<Product> Products => _products.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Region()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Region(Guid id, string name, List<Product> products) : base(id)
    {
        Name = name;
        _products = products;
    }

    public static Region Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Region(Guid.NewGuid(), name, []);
    }

    public static Region Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Region(id, name, []);
    }

    public static Region Create(Guid id, string name, List<Product> products)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Region(id, name, products);
    }
}