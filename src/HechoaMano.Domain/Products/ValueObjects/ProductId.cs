using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; }

    private ProductId(Guid value) => Value = value;

    public static ProductId Create() => new(Guid.NewGuid());
    public static ProductId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
