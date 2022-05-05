namespace FirstWebAPI.ViewModels
{
    public class VM_Get_Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string CreatedDate { get; set; }
    }
}
