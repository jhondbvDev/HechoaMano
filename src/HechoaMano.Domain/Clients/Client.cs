using HechoaMano.Domain.Clients.ValueObjects;
using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Employees;

namespace HechoaMano.Domain.Clients;

public sealed class Client : AggregateRoot<UserId>
{
    public string Name { get; }
    public string DocumentId { get; }
    public ContactInformation ContactInfo { get; }
    public string ShopName { get; }
    public decimal Discount { get; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; }

    private Client(
        UserId id,
        string name,
        string documentId,
        ContactInformation contactInfo,
        string shopName,
        decimal discount,
        DateTime createdDate,
        DateTime updatedDate) : base(id)
    {
        Name = name;
        DocumentId = documentId;
        ContactInfo = contactInfo;
        ShopName = shopName;
        Discount = discount;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Client Create(string name, string documentId, ContactInformation contactInfo, string shopName, decimal discount)
    {
        return new(UserId.CreateUnique(), name, documentId, contactInfo, shopName, discount, DateTime.Now, DateTime.Now);
    }
}
