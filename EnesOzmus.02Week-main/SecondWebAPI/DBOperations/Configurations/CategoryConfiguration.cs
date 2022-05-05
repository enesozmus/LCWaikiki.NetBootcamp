using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondWebAPI.Entities;

namespace SecondWebAPI.DBOperations.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        // ödev isterleri arasında olduğu için eklenmiştir. Normalde tercih edilen FluentValidation kütüphanesidir.
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}