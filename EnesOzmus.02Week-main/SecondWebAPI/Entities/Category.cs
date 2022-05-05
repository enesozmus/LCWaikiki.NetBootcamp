using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }


        // ***** many products ***** //
        public ICollection<Product> Products { get; set; }
    }
}
