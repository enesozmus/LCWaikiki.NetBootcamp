namespace FirstWebAPI.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
        public string Fabric { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
    }
}
