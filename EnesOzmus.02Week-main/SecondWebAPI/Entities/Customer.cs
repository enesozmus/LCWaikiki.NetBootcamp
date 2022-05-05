using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
