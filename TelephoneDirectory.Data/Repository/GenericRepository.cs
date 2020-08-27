using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Data.Repository
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {

        public async Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] include)
        {
            using (var context = new TelephoneDirectoryContext())
            {
                return include != null
                           ? await context.Set<TEntity>().IncludeMultiple(include).ToListAsync()
                           : await context.Set<TEntity>().ToListAsync();
            }
        }
        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] include)
        {
            using (var context = new TelephoneDirectoryContext())
            {
                return include != null
                           ? await context.Set<TEntity>().IncludeMultiple(include).Where(where).ToListAsync()
                           : await context.Set<TEntity>().Where(where).ToListAsync();
            }
        }

        public async Task<TId> Insert(TEntity entity)
        {
            using (var context = new TelephoneDirectoryContext())
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }

            return entity.Id;
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TelephoneDirectoryContext())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TId id)
        {
            using (var context = new TelephoneDirectoryContext())
            {
                var entity = context.Set<TEntity>().FirstOrDefault(c => c.Id.Equals(id));
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }

        }


    }
}
