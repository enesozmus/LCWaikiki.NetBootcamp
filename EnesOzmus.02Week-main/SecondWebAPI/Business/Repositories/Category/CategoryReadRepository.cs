using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
