using FirstWebAPI.Models.Common;

namespace FirstWebAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }


        // ***** many products ***** //
        public ICollection<Product> Products { get; set; }
    }
}
