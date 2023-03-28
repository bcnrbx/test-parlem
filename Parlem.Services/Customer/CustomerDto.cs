namespace Parlem.Services.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string DocType { get; set; } = default!;
        public string DocNum { get; set; } = default!;
        public string CustomerId { get; set; } = default!;
        public string GivenName { get; set; } = default!;
        public string FamilyName1 { get; set; } = default!;
        public string FamilyName2 { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }
}
