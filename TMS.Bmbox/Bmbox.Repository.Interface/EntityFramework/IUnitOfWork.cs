using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : class;

    void Commit();

    IAccountRepository AccountRepository { get; }
    IAccountTypeRepository AccountTypeRepository { get; }
    IAccountMovieRepository AccountMovieRepository { get; }
    IAccountTvSeriesRepository AccountTvSeriesRepository { get; }
    IAccountBookRepository AccountBookRepository { get; }
    
  }
}
