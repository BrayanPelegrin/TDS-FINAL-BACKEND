﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await Task.Run(() => _entity.ToList().Where(x => x.EstadoId != Convert.ToInt32(Enums.Estados.Eliminado) && x.EstadoId != Convert.ToInt32(Enums.Estados.Descontinuado))); 
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return  await Task.Run(()=>  _entity.AsNoTracking().Where(x => x.Id == id).First());
        }

        public async Task<T> SaveAsync(T entity)
        {
            
            if(entity.Id == 0)
            {
                 await _entity.AddAsync(entity);
            }
            else
            {
                await Task.Run(() => _entity.Update(entity));
            }

            await _context.SaveChangesAsync();
            return entity;

        }

       

        public async Task<T> DeleteAsync(T entity)
        {
            var entidad = await Task.Run(() => _entity.AsNoTracking().Where(x => x.Id == entity.Id).First()); ;
            if (entidad == null)
            {
                return null;
            }
            entidad.EstadoId = (int)Enums.Estados.Eliminado;
            await Task.Run(() => _entity.Update(entidad));
            await _context.SaveChangesAsync();
            return entidad; 
        }

        public async Task<IQueryable<T>> GetAllWithInclude(params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _entity;
            query = await Task.Run(() =>
            {
                foreach (var include in IncludeProperties)
                {
                    query = query.Include(include);
                }
                return query;
            });
            
            return query;
        }
    }
}
