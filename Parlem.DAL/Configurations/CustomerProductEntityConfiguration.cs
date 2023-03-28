using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parlem.DAL.Entities;

namespace Parlem.DAL.Configurations
{
    public class CustomerProductEntityConfiguration : IEntityTypeConfiguration<CustomerProductEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerProductEntity> builder)
        {
            builder.ToTable("CustomerProduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductTypeName).IsRequired();
            builder.Property(x => x.NumeracioTerminal).IsRequired();
            builder.Property(x => x.SoldAt).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.Products).HasPrincipalKey(x => x.CustomerId).HasForeignKey(x => x.CustomerId);
            builder.HasData(new List<CustomerProductEntity>()
            {
                new CustomerProductEntity() { Id = 1111111, ProductName = "FIBRA 1000 ADAMO", ProductTypeName = "ftth", NumeracioTerminal = 933933933, SoldAt = new DateTime(2019, 1, 9, 14, 26, 17), CustomerId = "11111" },
                new CustomerProductEntity() { Id = 1111112, ProductName = "FIBRA 500 ADAMO", ProductTypeName = "ftth", NumeracioTerminal = 944944944, SoldAt = new DateTime(2018, 1, 1, 10, 0, 20), CustomerId = "11111" }
            });
        }
    }
}
