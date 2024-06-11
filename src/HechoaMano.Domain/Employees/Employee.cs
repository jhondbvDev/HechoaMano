using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;

namespace HechoaMano.Domain.Employees;

public sealed class Employee : AggregateRoot<UserId>
{
    public string Name { get; private set; }
    public string DocumentId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    private Employee(UserId id, string name, string documentId, DateTime createdDate, DateTime updatedDate) : base(id)
    {
        Name = name;
        DocumentId = documentId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Employee Create(string name, string documentId) 
    {
        return new(UserId.Create(), name, documentId, DateTime.Now, DateTime.Now);
    }
}