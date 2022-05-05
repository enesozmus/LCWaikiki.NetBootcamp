using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.Application.Repositories;
using SecondWebAPI.DBOperations;
using SecondWebAPI.DBOperations.Validations;
using SecondWebAPI.Mappings.Helpers;

namespace SecondWebAPI.DependencyResolvers
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            /// <summary>
            /// Entity Framework ve Microsoft SQL Server kullanılmıştır.
            /// </summary>
            services.AddDbContext<SecondDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            /// <summary>
            /// Generic Repository
            /// </summary>
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            /// <summary>
            /// FluentValidation Kütüphanesi
            /// </summary>
            services.AddControllers().AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>()).AddFluentValidation(
                );


            /// <summary>
            /// AutoMapper Kütüphanesi
            /// </summary>
            var profiles = ProfileHelper.GetProfiles();
            var mapConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = mapConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
