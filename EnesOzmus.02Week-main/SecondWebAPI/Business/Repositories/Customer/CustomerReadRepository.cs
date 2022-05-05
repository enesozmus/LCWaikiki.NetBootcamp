using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
