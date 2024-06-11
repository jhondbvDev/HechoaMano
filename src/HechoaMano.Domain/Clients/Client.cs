using HechoaMano.Domain.Clients.ValueObjects;
using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;

namespace HechoaMano.Domain.Clients;

public sealed class Client : AggregateRoot<UserId>
{
    public string Name { get; private set; }
    public string DocumentId { get; private set; }
    public ContactInformation ContactInfo { get; private set; }
    public string ShopName { get; private set; }
    public decimal Discount { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

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
        return new(UserId.Create(), name, documentId, contactInfo, shopName, discount, DateTime.Now, DateTime.Now);
    }
}