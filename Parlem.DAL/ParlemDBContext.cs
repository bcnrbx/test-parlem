using Microsoft.EntityFrameworkCore;
using Parlem.DAL.Configurations;
using Parlem.DAL.Entities;

namespace Parlem.DAL
{
    public class ParlemDBContext : DbContext
    {
        public ParlemDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerProductEntityConfiguration());
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerProductEntity> CustomerProducts { get; set; }
    }
}
