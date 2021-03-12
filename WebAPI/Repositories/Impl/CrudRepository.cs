#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using DbContext = WebAPI.Database.DbContext;

namespace WebAPI.Repositories.Impl
{
    public class CrudRepository<TId, TModel> : ICrudRepository<TId, TModel> 
        where TId : IComparable<TId>
        where TModel : BaseEntity<TId>
    {
        protected readonly DbContext Context;

        public CrudRepository(DbContext context) => Context = context;
        
        public virtual IEnumerable<TModel> All() => Context.Set<TModel>();

        public virtual TModel Create(TModel entity)
        {
            return Context.Set<TModel>().Add(entity).Entity;
        }

        public virtual TModel? Read(TId id)
        {
            return Context.Set<TModel>().FirstOrDefault(m => m.Id.CompareTo(id) == 0);
        }

        public virtual TModel Update(TModel entity)
        {
            if (Read(entity.Id) is null) return Create(entity);
            
            var update = Context.Entry(entity).Entity;
            return update;

        }

        public virtual void Delete(TId id)
        {
            if (Read(id) is not { } model) return;
            
            Context.Set<TModel>().Remove(model);
        }

        public void Save() => Context.SaveChanges();
    }
}
