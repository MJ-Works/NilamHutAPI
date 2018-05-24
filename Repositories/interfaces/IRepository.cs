using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NilamHutAPI.Repositories.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<int> Add(TEntity entity);
        Task<int> AddRange(IEnumerable<TEntity> entities);

        Task<int> Update(object key, TEntity entity);

        Task<int> Remove(TEntity entity);
        Task<int> RemoveRange(IEnumerable<TEntity> entities);
    }
}