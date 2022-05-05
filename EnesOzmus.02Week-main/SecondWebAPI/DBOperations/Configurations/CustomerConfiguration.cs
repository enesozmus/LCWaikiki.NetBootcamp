using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondWebAPI.Entities;

namespace SecondWebAPI.DBOperations.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        // ödev isterleri arasında olduğu için eklenmiştir. Normalde tercih edilen FluentValidation kütüphanesidir.
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.EMail).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
        }
    }
}
