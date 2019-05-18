using System;
using System.Linq;
using System.Linq.Expressions;

namespace NiboChallenge.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Get(Func<TEntity, bool> Where = null, params Expression<Func<TEntity, object>>[] Include);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
