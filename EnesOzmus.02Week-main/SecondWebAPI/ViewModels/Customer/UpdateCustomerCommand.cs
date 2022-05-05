namespace SecondWebAPI.ViewModels
{
    public class UpdateCustomerCommand
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
