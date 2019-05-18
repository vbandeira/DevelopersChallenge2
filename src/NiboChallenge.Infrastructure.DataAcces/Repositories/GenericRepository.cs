using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NiboChallenge.Infrastructure.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly DbContext _context;
        private DbSet<TEntity> _entities;

        public bool AutoSaveChanges { get; set; }

        public GenericRepository(DbContext context, bool autoSaveChanges = false)
        {
            _context = context;
            _entities = context.Set<TEntity>();
            AutoSaveChanges = autoSaveChanges;
        }

        public virtual IQueryable<TEntity> Get(Func<TEntity, bool> Where = null, params Expression<Func<TEntity, object>>[] Include)
        {
            IQueryable<TEntity> result = _entities;

            if (Where != null)
                result = result.Where(Where).AsQueryable();

            if (Include.Any())
            {
                foreach (var include in Include)
                    result = result.Include(include);
            }

            return result;
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);

            if (AutoSaveChanges) this.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);

            if (AutoSaveChanges) this.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);

            if (AutoSaveChanges) this.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
