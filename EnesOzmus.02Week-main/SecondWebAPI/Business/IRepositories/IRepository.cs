using Microsoft.EntityFrameworkCore;
using SecondWebAPI.Entities.Common;

namespace SecondWebAPI.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
