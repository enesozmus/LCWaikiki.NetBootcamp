using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;

namespace SecondWebAPI.Application.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(SecondDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
