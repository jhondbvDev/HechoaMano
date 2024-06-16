using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;

namespace HechoaMano.Domain.Employees;

public sealed class Employee : AggregateRoot<UserId>
{
    public string Name { get; private set; }
    public string DocumentId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Employee()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Employee(UserId id, string name, string documentId, DateTime createdDate, DateTime updatedDate) : base(id)
    {
        Name = name;
        DocumentId = documentId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Employee Create(UserId id, string name, string documentId, DateTime createdDate)
    {
        return new(id, name, documentId, createdDate, DateTime.Now);
    }

    public static Employee Create(string name, string documentId) 
    {
        return new(UserId.Create(), name, documentId, DateTime.Now, DateTime.Now);
    }
}