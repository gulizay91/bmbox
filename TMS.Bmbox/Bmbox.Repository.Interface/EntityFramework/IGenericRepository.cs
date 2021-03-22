using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IGenericRepository<TEntity, TKey>
  {
    TEntity Get(TKey id);

    IQueryable<TEntity> GetAll(int page, int pageCount);

    TEntity Insert(TEntity entity, string userName);
    TEntity Update(TEntity entity, string userName);
    TEntity FindWithInclude(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);
    IQueryable<TEntity> FilterWithInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties);
  }
}
