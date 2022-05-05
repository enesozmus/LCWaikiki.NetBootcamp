using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondWebAPI.Entities;

namespace SecondWebAPI.DBOperations.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        // ödev isterleri arasında olduğu için eklenmiştir. Normalde tercih edilen FluentValidation kütüphanesidir.
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Address).IsRequired();
        }
    }
}
