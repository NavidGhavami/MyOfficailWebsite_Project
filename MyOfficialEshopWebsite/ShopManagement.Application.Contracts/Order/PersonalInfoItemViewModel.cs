namespace ShopManagement.Application.Contract.Order
{
    public class PersonalInfoItemViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PlaqueNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
