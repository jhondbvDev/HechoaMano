using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Common.ValueObjects;

namespace HechoaMano.Domain.Employees
{
    public sealed class Employee : AggregateRoot<UserId>
    {
        public string Name { get; }
        public string DocumentId { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; }

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
}
