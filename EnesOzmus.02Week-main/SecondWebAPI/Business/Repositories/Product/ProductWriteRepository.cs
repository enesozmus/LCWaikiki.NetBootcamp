using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
