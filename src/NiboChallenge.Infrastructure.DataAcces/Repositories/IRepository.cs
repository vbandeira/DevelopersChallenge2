using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NiboChallenge.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Returns all entities saved in the repository
        /// </summary>
        /// <returns>Collection of entities</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Returns filtered entities saved in the repository
        /// </summary>
        /// <param name="Where">Filter function to be applied in the repository</param>
        /// <returns>Collection of filtered entities</returns>
        IQueryable<TEntity> Get(Func<TEntity, bool> Where);

        /// <summary>
        /// Returns all entities with their dependencies
        /// </summary>
        /// <param name="Include">Lambdas with the properties that must be returned by the query</param>
        /// <returns>Collection of entities with the dependencies included</returns>
        IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] Include);

        /// <summary>
        /// Returns all entities that matches the Where function and the dependencies
        /// </summary>
        /// <param name="Where">Filter function to be applied in the repository</param>
        /// <param name="Include">Lambdas with the properties that must be returned by the query</param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Func<TEntity, bool> Where , params Expression<Func<TEntity, object>>[] Include);

        /// <summary>
        /// Adds a single entity to the repository
        /// </summary>
        /// <param name="entity">Entity to be added to the repository</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds a collection of entities to the repository
        /// </summary>
        /// <param name="entities">Collection of entitites to be added</param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an existing entity using its Id to reference the old one
        /// </summary>
        /// <param name="entity">Updated entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an existing entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Forces the persistence (save) of the data
        /// </summary>
        void SaveChanges();
    }
}
