using _0_Framework.Domain;

namespace ShopManagement.Domain.Order
{
    public class PersonalInfoItem : EntityBase
    {
        public long AccountId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Company { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public string PlaqueNo { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }

        public PersonalInfoItem(long accountId, string name, string family, string company, string country, string state,
            string city, string street, string postalCode, string plaqueNo, string mobile, string email, string description)
        {
            AccountId = accountId;
            Name = name;
            Family = family;
            Company = company;
            Country = country;
            State = state;
            City = city;
            Street = street;
            PostalCode = postalCode;
            PlaqueNo = plaqueNo;
            Mobile = mobile;
            Email = email;
            Description = description;
        }
    }
}
