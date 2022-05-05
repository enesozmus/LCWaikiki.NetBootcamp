using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Application.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);                            // bir veri ekleme
        bool Update(T model);                                           // bir veriyi güncelleme
        Task<bool> RemoveAsync(int id);                         // bir veriyi unique ID'sini kullanarak silme
        Task<int> SaveAsync();                                          // işlemi kaydetme
    }
}
