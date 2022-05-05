using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
