#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class CrudRepository<TId, TModel> : ICrudRepository<TId, TModel> 
        where TId : IComparable<TId>
        where TModel : BaseModel<TId>
    {
        protected readonly DbContext Context;

        public CrudRepository(DbContext context) => Context = context;

        public IEnumerable<TModel> All() => Context.Set<TModel>();

        public virtual TModel Create(TModel model)
        {
            var result = Context.Set<TModel>().Add(model).Entity;
            Context.SaveChanges();
            return result;
        }

        public virtual TModel? Read(TId id)
        {
            return Context.Set<TModel>().FirstOrDefault(m => m.Id.CompareTo(id) == 0);
        }

        public virtual TModel Update(TModel model)
        {
            if (Read(model.Id) is null) return Create(model);
            
            var update = Context.Entry(model).Entity;
            Context.SaveChanges();
            return update;

        }

        public virtual void Delete(TId id)
        {
            if (Read(id) is not { } model) return;
            
            Context.Set<TModel>().Remove(model);
            Context.SaveChanges();
        }

        public void Save() => Context.SaveChanges();
    }
}
