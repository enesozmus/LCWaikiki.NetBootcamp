namespace FirstWebAPI.ViewModels
{
    public class VM_Update_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedDate { get; set; }
    }
}
