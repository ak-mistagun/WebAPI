#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ICrudRepository<in TId, TModel> 
        where TId : IComparable<TId>
        where TModel : BaseModel<TId>
    {
        public IEnumerable<TModel> All(); 
        public TModel Create(TModel model);
        public TModel? Read(TId id);
        public TModel Update(TModel model);
        public void Delete(TId id);
        public void Save();
    }
}
