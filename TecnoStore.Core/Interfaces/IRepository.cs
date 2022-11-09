using System.Linq.Expressions;

namespace TecnoStore.Core.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> SaveAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<IQueryable<T>> GetAllWithInclude(params Expression<Func<T,object>>[] IncludeProperties);

    }
}
