using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Clients.ValueObjects
{
    public sealed class ContactInformation : ValueObject
    {
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }

        private ContactInformation(string address, string phoneNumber, string city)
        {
            Address = address;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public static ContactInformation Create(string address, string phoneNumber, string city)
        {
            return new(address, phoneNumber, city);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
            yield return PhoneNumber;
            yield return City;
        }
    }
}
