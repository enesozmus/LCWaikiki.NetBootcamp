namespace FirstWebAPI.ViewModels
{
    public class VM_Create_Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
    }
}
