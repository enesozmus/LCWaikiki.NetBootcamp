using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondWebAPI.Entities;

namespace SecondWebAPI.DBOperations.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        // ödev isterleri arasında olduğu için eklenmiştir. Normalde tercih edilen FluentValidation kütüphanesidir.
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Brand).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
