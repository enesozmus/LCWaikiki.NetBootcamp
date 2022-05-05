using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities;
using SecondWebAPI.Entities.Common;
using System.Linq.Expressions;

namespace SecondWebAPI.Application.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly SecondDbContext _dbcontext;

        public ReadRepository(SecondDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public DbSet<T> Table => _dbcontext.Set<T>();

        // ***** Tüm verileri elde etme ****** //
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        // ***** Unique bir id'ye uyan veriyi elde etme ****** //
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        // ***** Bir şarta uyan tüm verileri elde etme ****** //
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();       // tracking true değilse maliyeti düşür!
            return query;
        }

        // ***** Bir şarta uyan bir veriyi elde etme ****** //
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
           if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
    }
}
