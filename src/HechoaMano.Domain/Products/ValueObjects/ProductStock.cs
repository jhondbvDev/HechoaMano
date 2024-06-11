using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.ValueObjects;

public sealed class ProductStock : ValueObject
{
    public int Value { get; }

    private ProductStock(int value) => Value = value;

    public static ProductStock Create() => new(0);
    public static ProductStock Create(int value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
