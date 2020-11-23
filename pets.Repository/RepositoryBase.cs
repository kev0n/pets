using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Interfaces;

namespace pets.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> GetAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return  RepositoryContext.Set<T>().Find(id);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Queryable.Where(RepositoryContext.Set<T>(), expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            RepositoryContext.Entry(entity).State = EntityState.Modified;
            return RepositoryContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            return RepositoryContext.SaveChangesAsync();
        }
    }
}