using System.Linq.Expressions;

namespace odev2.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        void UpdateAsync(T entity);
        void RemoveAsync(T entity);
        void RemoveRangeAsync(IEnumerable<T> entities);
    }
}
