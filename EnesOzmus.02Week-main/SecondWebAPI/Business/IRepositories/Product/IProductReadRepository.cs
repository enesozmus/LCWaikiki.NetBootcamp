using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Interfaces
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByCategoryId(int id);
        Task<Product> GetProductsWithCategoryName(int id);
        Task<IQueryable<Product>> GetQuery();
    }
}
