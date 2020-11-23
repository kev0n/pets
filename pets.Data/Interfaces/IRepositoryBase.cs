using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pets.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);


        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}