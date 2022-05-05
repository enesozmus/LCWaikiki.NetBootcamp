using AutoMapper;
using FirstWebAPI.Models;
using FirstWebAPI.ViewModels;

namespace FirstWebAPI.Common
{
    public class MappingProfile : Profile
    {
        // AutoMapper Kütüphanesi
        public MappingProfile()
        {
            CreateMap<Product, VM_Get_Products>()
                                                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Category, VM_Get_Categories>();

            CreateMap<VM_Create_Product, Product>();
            CreateMap<VM_Create_Category, Category>();

            CreateMap<VM_Update_Product, Product>();
            CreateMap<VM_Update_Category, Category>();


            // opsiyonel
            CreateMap<Product, VM_Get_Product>()
                                                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                                                    .ForMember(x => x.Features, opt => opt
                                                    .MapFrom(src => src.Features != null ? src.Features.Where(m => m.Id == src.Id).ToList() : null));
        }
    }
}
