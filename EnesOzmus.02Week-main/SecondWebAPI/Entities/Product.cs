using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Products_Orders = new HashSet<Product_Order>();
        }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }


        // ***** one category ***** //
        public int CategoryId { get; set; }
        public Category Category { get; set; }                  // → opsiyonel Bir ürünün sadece tek bir kategorisi olabilir.


        // ***** many orders ***** //
        public ICollection<Product_Order> Products_Orders { get; set; }         // → bir ürün birden fazla siparişin içinde olabilir.
    }
}
