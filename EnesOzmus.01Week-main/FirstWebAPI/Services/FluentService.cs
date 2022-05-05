using FirstWebAPI.Validations;
using FluentValidation.AspNetCore;

namespace FirstWebAPI.Services
{
    public static class FluentService
    {
        public static void AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());
        }
    }
}
