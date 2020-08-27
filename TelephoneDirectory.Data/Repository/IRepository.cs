using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Data.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] include);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include);
        Task<TId> Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TId id);
    }
}
