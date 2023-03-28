namespace Parlem.DAL.Entities
{
    public class CustomerProductEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductTypeName { get; set; } = default!;
        public int NumeracioTerminal { get; set; }
        public DateTime SoldAt { get; set; }
        public string CustomerId { get; set; } = default!;
        public CustomerEntity Customer { get; set; } = default!;
    }
}
