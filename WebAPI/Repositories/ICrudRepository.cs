#nullable enable

using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ICrudRepository<in TId, TEntity> 
        where TId : IComparable<TId>
        where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// Return entities. Method don't save change into Database.
        /// </summary>
        /// <returns>collection of entities</returns>
        public IEnumerable<TEntity> All();
        /// <summary>
        /// Create new entity. Method don't save change into Database.
        /// </summary>
        /// <param name="entity">entity with empty id</param>
        /// <returns></returns>
        public TEntity Create(TEntity entity);
        /// <summary>
        /// Find entity by id. Method don't save change into Database.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        public TEntity? Read(TId id);
        /// <summary>
        /// Update entity if id is not empty, else call method <see cref="Create"/>.
        /// Method don't save change into Database.
        /// </summary>
        /// <param name="entity">entity with id or empty id</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity);
        /// <summary>
        /// Delete entity by id. Method don't save change into Database.
        /// </summary>
        /// <param name="id">entity id</param>
        public void Delete(TId id);
        /// <summary>
        /// Save changes into Database.
        /// </summary>
        public void Save();
    }
}
