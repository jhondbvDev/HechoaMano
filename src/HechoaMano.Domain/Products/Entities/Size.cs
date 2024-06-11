using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public class Size : Entity<Guid>
{
    public string Name { get; private set; }
    private readonly List<Product> _products = [];
    public virtual IReadOnlyList<Product> Products => _products.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Size()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Size(Guid id, string name, List<Product> products) : base(id)
    {
        Name = name;
        _products = products;
    }

    public static Size Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Size(Guid.NewGuid(), name, []);
    }

    public static Size Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Size(id, name, []);
    }

    public static Size Create(Guid id, string name, List<Product> products)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Size(id, name, products);
    }
}