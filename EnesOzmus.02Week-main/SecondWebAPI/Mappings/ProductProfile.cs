using AutoMapper;
using SecondWebAPI.Entities;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductsViewModel>();

            CreateMap<Product, GetProductsVMByCategory>()
                            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, GetProductDetailQuery>()
                            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateProductCommand, Product>();

            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
