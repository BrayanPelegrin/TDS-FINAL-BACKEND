using System.Linq.Expressions;

namespace TecnoStore.Core.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public T Save(T entity);
        public T Delete(T entity);
        public IQueryable<T> GetAllWithInclude(params Expression<Func<T,object>>[] IncludeProperties);
        public IQueryable<T> GetByIdWithInclude(int id, params Expression<Func<T, object>>[] IncludeProperties);
    }
}
