using SecondWebAPI.Entities;
using SecondWebAPI.Entities.Common;
using System.Linq.Expressions;

namespace SecondWebAPI.Application.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {                                                            
        Task<IReadOnlyList<T>> GetAllAsync();                                                                                      // Tüm verileri elde etme
        Task<T> GetByIdAsync(int id, bool tracking = true);                                                                 // Unique bir id'ye uyan veriyi elde etme
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);    // Bir şarta uyan tüm verileri elde etme
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);       // Bir şarta uyan bir veriyi elde etme
    }
}
