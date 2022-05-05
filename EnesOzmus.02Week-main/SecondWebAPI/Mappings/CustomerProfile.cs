using AutoMapper;
using SecondWebAPI.Entities;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomersViewModel>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}
