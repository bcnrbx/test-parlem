using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parlem.DAL.Entities;

namespace Parlem.DAL.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.HasAlternateKey(x => x.CustomerId);
            builder.HasIndex(x => x.Id).IsUnique(true);
            builder.Property(x => x.DocNum).IsRequired();
            builder.Property(x => x.DocType).IsRequired();
            builder.Property(x => x.GivenName).IsRequired();
            builder.Property(x => x.FamilyName1).IsRequired();
            builder.Property(x => x.FamilyName2).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.HasData(new List<CustomerEntity>()
            {
                new CustomerEntity() { Id = 555555, CustomerId = "11111", DocType = "nif", DocNum = "11223344E", Email = "it@parlem.com", GivenName = "Enrique", FamilyName1 = "Parlem", FamilyName2 = "Parlem", Phone = "668668668"},
                new CustomerEntity() { Id = 555556, CustomerId = "11112", DocType = "nif", DocNum = "22334455E", Email = "it2@parlem.com", GivenName = "Test", FamilyName1 = "Parlem", FamilyName2 = "Parlem", Phone = "600600600"}
            });
        }
    }
}
