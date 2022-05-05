
#nullable disable
using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Entities;

namespace SecondWebAPI.DBOperations.SeedData
{
    public class DataGenerator
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SecondDbContext>();

                context.Database.Migrate();     // migration varsa veritabanını tohumlar

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer { FullName = "İhsan Yenilmez", EMail = "ihsan@seeddata.com",   PhoneNumber = "0505 555 1111", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Umay Zengin",    EMail = "umay@seeddata.com",    PhoneNumber = "0505 555 2222", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Emre Demir",     EMail = "emre@seeddata.com",    PhoneNumber = "0505 555 3333", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Emine Yıldırım", EMail = "emine@seeddata.com",   PhoneNumber = "0505 555 4444", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Salih Yurdakul", EMail = "salih@seeddata.com",   PhoneNumber = "0505 555 5555", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Zafer Çağlayan", EMail = "zafer@seeddata.com",   PhoneNumber = "0505 555 6666", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Hakan Filiz",    EMail = "hakan@seeddata.com",   PhoneNumber = "0505 555 7777", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Berrin Miral",   EMail = "berrin@seeddata.com",  PhoneNumber = "0505 555 8888", CreatedDate = new DateTime(2022, 04, 16)},
                        new Customer { FullName = "Selim Karaca",   EMail = "selim@seeddata.com",   PhoneNumber = "0505 555 9999", CreatedDate = new DateTime(2022, 04, 16)}
                    });
                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category {Name = "Kazaklar", Description = "Kış Sezonu", CreatedDate =new DateTime(2022, 04, 16)},
                        new Category {Name = "Gömlekler", Description = "Yaz Sezonu", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Pantolonlar", Description = "Bütün Sezonlar", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Montlar", Description = "Kış Sezonu", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Hırkalar", Description = "Kış Sezonu", CreatedDate = new DateTime(2022, 04, 16) }
                    });

                    context.SaveChanges();
                }

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Order>()
                    {
                        new Order { CustomerId = 1, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 1, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 1, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 2, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 2, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 3, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false},
                        new Order { CustomerId = 9, Description = "Ürün Açıklaması",    Address = "Sipariş Adresi", CreatedDate = new DateTime(2022, 04, 16), Status = false}
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product { CategoryId = 1, Brand ="LCW", Name = "LCW CASUAL Kısa Kollu Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate =new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 1, Brand ="LCW", Name = "LCW BASIC Yarım Balıkçı Yaka Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate =new DateTime(2022, 04, 16)},
                        new Product { CategoryId = 1, Brand ="LCW", Name = "LCW CLASSIC Bisiklet Yaka Triko Kazak", Price = 109.99m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 2, Brand ="LCW", Name = "LCW Jean Gömlek", Price = 199.99m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 2, Brand ="LCW", Name = "LCW CLASSIC Slim Gömlek", Price = 199.99m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 3, Brand ="LCW", Name = "LCW Kargo Pantolon", Price = 149.99m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 3, Brand ="LCW", Name = "LCW Armürlü Pantolon", Price = 149.99m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 4, Brand ="LCW", Name = "LCW Standart Kalıp Kapüşonlu Mont", Price = 419.9m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) },
                        new Product { CategoryId = 4, Brand ="LCW", Name = "LCW Standart Kalıp İnce Mont", Price = 419.9m, Stock = 250, CreatedDate = new DateTime(2022, 04, 16) }
                    });

                    context.SaveChanges();
                }

                if (!context.Products_Orders.Any())
                {
                    context.Products_Orders.AddRange(new List<Product_Order>()
                    {
                        new Product_Order { ProductId = 1, OrderId = 1},
                        new Product_Order { ProductId = 2, OrderId = 2},
                        new Product_Order { ProductId = 1, OrderId = 3},
                        new Product_Order { ProductId = 1, OrderId = 4},
                        new Product_Order { ProductId = 2, OrderId = 5},
                        new Product_Order { ProductId = 4, OrderId = 5},
                        new Product_Order { ProductId = 4, OrderId = 2},
                        new Product_Order { ProductId = 5, OrderId = 1},
                        new Product_Order { ProductId = 7, OrderId = 7}
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}