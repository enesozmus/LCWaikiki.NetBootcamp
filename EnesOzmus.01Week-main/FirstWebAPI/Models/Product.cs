using FirstWebAPI.Models.Common;

namespace FirstWebAPI.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }


        // ***** one category ***** //
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // ***** opsiyonel → Ürünün detayları kısmında sadece gösterilmek istendi. ***** //
        public ICollection<ProductFeature> Features { get; set; }
    }
}
