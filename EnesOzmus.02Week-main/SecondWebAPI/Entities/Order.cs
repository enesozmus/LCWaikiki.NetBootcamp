using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; } = true;

        // ***** many products ***** //
        // → bir siparişin içinde birden fazla ürün olabilir
        public ICollection<Product_Order> Products_Orders { get; set; }

        // ***** one customer ***** //
        // → belirli bir sipariş sadece bir müşteriye ait olabilir.
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}