using Bmbox.Repository.Interface.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bmbox.Repository.EntityFramework
{
  public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
   where TEntity : class
  {
    private readonly DbContext _dbContext;
    private DbSet<TEntity> _dbSet;

    private DbSet<TEntity> Table
    {
      get
      {
        if (_dbSet == null)
          _dbSet = _dbContext.Set<TEntity>();

        return _dbSet;
      }
    }

    public GenericRepository(DbContext dbContext)
    {
      //dbContext.Configuration.LazyLoadingEnabled = false;
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<TEntity>();
    }

    public TEntity Get(TKey id)
    {
      return _dbSet.Find(id);
    }

    public IQueryable<TEntity> GetAllQueryable()
    {
      return Table;
    }

    public TEntity Insert(TEntity entity, string userName)
    {
      try
      {
        if (entity.GetType().GetProperty("CreatedBy") != null)
          entity.GetType().GetProperty("CreatedBy").SetValue(entity, userName, null);
        if (entity.GetType().GetProperty("CreatedDatetime") != null)
          entity.GetType().GetProperty("CreatedDatetime").SetValue(entity, DateTime.Now, null);
        if (entity.GetType().GetProperty("IsActive") != null)
          entity.GetType().GetProperty("IsActive").SetValue(entity, true, null);

        _dbSet.Add(entity);
        //Commit();

        return entity;
      }
      catch (Exception ex)
      {
        // TODO : Logger eklenecek.
        return null;
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public TEntity Update(TEntity entity, string userName)
    {
      try
      {
        if (entity.GetType().GetProperty("UpdatedBy") != null)
          entity.GetType().GetProperty("UpdatedBy").SetValue(entity, userName, null);
        if (entity.GetType().GetProperty("UpdatedDatetime") != null)
          entity.GetType().GetProperty("UpdatedDatetime").SetValue(entity, DateTime.Now, null);

        //_dbContext.Set<TEntity>().Update(entity);
        _dbSet.Update(entity);
        //Commit();

        return entity;
      }
      catch (Exception ex)
      {
        // TODO : Logger eklenecek.
        return null;
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public TEntity FindWithInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
    {
      try
      {
        IQueryable<TEntity> result = _dbSet;

        if (includeProperties != null)
        {
          foreach (var property in includeProperties)
          {
            result = result.Include(property);
          }

        }

        if (filter != null)
          result = result.Where(filter);

        return result.FirstOrDefault();
      }
      catch (Exception ex)
      {
        return null;
        // TODO : Logger eklenecek.
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public IQueryable<TEntity> FilterWithInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
    {
      try
      {
        IQueryable<TEntity> result = _dbSet.AsQueryable();

        if (includeProperties != null)
        {
          foreach (var property in includeProperties)
          {
            result = result.Include(property);
          }

        }

        if (filter != null)
          result = result.Where(filter);


        return result;
      }
      catch (Exception ex)
      {
        return null;
        // TODO : Logger eklenecek.
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public IQueryable<TEntity> GetAll(int page, int pageCount)
    {
      var pageSize = (page - 1) * pageCount;

      return _dbSet.Skip(pageSize).Take(pageCount);
    }


  }
}
