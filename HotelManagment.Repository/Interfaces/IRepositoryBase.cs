using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Interfaces
{
    public interface IRepositoryBase<T> : ISavable where T : class
    {
        Task<List<T>> GetAllAsync(string includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null);
        Task AddAsync(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
