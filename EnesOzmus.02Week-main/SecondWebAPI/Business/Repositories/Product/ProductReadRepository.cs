using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        private readonly SecondDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductReadRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }

        public ProductReadRepository(SecondDbContext dbcontext, IMapper mapper) : this(dbcontext)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<Product>> GetProductsByCategoryId(int id)
        {
            var productList = await _dbcontext.Products
                                            .Where(x => x.CategoryId == id)
                                            .Include(x => x.Category)
                                            .ToListAsync();

            return productList;
        }

        public async Task<Product> GetProductsWithCategoryName(int id)
        {
            var product = await _dbcontext.Products
                                    .Include(x => x.Category)
                                    .SingleOrDefaultAsync(m => m.Id == id);

            return product;
        }

        public async Task<IQueryable<Product>> GetQuery()
        {
            IQueryable<Product> query = _dbcontext.Products;
            return query;
        }
    }
}
