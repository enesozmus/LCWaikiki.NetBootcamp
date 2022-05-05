using AutoMapper;
using SecondWebAPI.Entities;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoriesViewModel>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
