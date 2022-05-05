using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SecondWebAPI.Application.Interfaces;
using SecondWebAPI.DBOperations;
using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Application.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly SecondDbContext _dbcontext;

        public WriteRepository(SecondDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public DbSet<T> Table => _dbcontext.Set<T>();
        public async Task<int> SaveAsync() => await _dbcontext.SaveChangesAsync();


        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return entityEntry.State == EntityState.Added;
        }


        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }


        public async Task<bool> RemoveAsync(int id)
        {
            if (id <= 0) throw new InvalidOperationException("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) throw new InvalidOperationException("Aradığınız ID'li veri bulunamadı!");
            Table.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
