using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TecnoStore.Core.Entities;
using TecnoStore.Core.Interfaces;
using TecnoStore.Infrastructure.Data;

namespace TecnoStore.Infrastructure.Repositories
{
    public class RepositorioBase<T>: IRepository<T> where T: EntidadBase 
    {
        private readonly TecnoStoreContext _context;
        protected  readonly DbSet<T> _entity;

        public RepositorioBase(TecnoStoreContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return  _entity.ToList();
        }

        public T GetById(int id)
        {
            return   _entity.AsNoTracking().Where(x => x.Id == id).First();
        }

        public T Save(T entity)
        {
            
            if(entity.Id == 0)
            {
                  _entity.Add(entity);
            }
            else
            {
                _entity.Update(entity);
            }

            _context.SaveChanges();
            return entity;

        }

       

        public T Delete(T entity)
        {
            var entidad = _entity.AsNoTracking().Where(x => x.Id == entity.Id).First();
            if (entidad == null)
            {
                return null;
            }
            entidad.EstadoId = (int)Enums.Estados.Eliminado;
            _entity.Update(entidad);
            _context.SaveChanges();
            return entidad; 
        }

        public  IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _entity;

                foreach (var include in IncludeProperties)
                {
                    query = query.Include(include);
                }
                return query.AsNoTracking();
        }

        public IQueryable<T> GetByIdWithInclude(int id, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _entity;

            foreach (var include in IncludeProperties)
            {
                query = query.Include(include);
            }
            return query.AsNoTracking().Where(x=>x.Id==id);
        }
    }
}
