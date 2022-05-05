using FirstWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                        new Product { Id = 1, CategoryId = 1, Name = "LCW CASUAL Kısa Kollu Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 2, CategoryId = 1, Name = "LCW BASIC Yarım Balıkçı Yaka Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 3, CategoryId = 1, Name = "LCW CLASSIC Bisiklet Yaka Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 4, CategoryId = 2, Name = "LCW Jean Gömlek", Price = 199.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 5, CategoryId = 2, Name = "LCW CLASSIC Slim Gömlek", Price = 199.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 6, CategoryId = 3, Name = "LCW Kargo Pantolon", Price = 149.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 7, CategoryId = 3, Name = "LCW Armürlü Pantolon", Price = 149.99m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 8, CategoryId = 4, Name = "LCW Standart Kalıp Kapüşonlu Mont", Price = 419.9m, Stock = 250, CreatedDate = "10.04.2022" },
                        new Product { Id = 9, CategoryId = 4, Name = "LCW Standart Kalıp İnce Mont", Price = 419.9m, Stock = 250, CreatedDate = "10.04.2022" }
                    ) ;

                context.Categories.AddRange(
                        new Category { Id = 1, Name = "Kazaklar", CreatedDate = "10.04.2022" },
                        new Category { Id = 2, Name = "Gömlekler", CreatedDate = "10.04.2022" },
                        new Category { Id = 3, Name = "Pantolonlar", CreatedDate = "10.04.2022" },
                        new Category { Id = 4, Name = "Montlar", CreatedDate = "10.04.2022" }
                    );

                context.Features.AddRange(
                        new ProductFeature { Id = 1, Brand ="LCW", Style= "dar", Fabric= "triko", Color = "bordo", Size = "S", ProductId = 1 },
                        new ProductFeature { Id = 2, Brand ="LCW", Style = "oversize/salaş", Fabric= "triko", Color = "haki", Size = "M", ProductId = 2 },
                        new ProductFeature { Id = 3, Brand ="LCW", Style = "oversize/salaş", Fabric= "keten", Color = "antrasit", Size = "L", ProductId = 3 },
                        new ProductFeature { Id = 4, Brand ="LCW", Style = "ekstra dar", Fabric= "polar", Color = "turuncu", Size = "L", ProductId = 4 },
                        new ProductFeature { Id = 5, Brand ="LCW", Style = "oversize/salaş", Fabric= "poplin", Color = "pembe", Size = "L", ProductId = 5 },
                        new ProductFeature { Id = 6, Brand ="LCW", Style = "dar", Fabric= "kadife", Color = "siyah", Size = "XL", ProductId = 6 },
                        new ProductFeature { Id = 7, Brand ="LCW", Style = "dar", Fabric= "keten", Color = "kahverengi", Size = "XL", ProductId = 7 },
                        new ProductFeature { Id = 8, Brand ="LCW", Style = "rahat kalıp", Fabric= "deri", Color = "petrol", Size = "XL", ProductId = 8 },
                        new ProductFeature { Id = 9, Brand ="LCW", Style = "rahat kalıp", Fabric= "pamuk", Color = "pembe", Size = "XL", ProductId = 9 }
                );

                context.SaveChanges();
            }
        }
    }
}
