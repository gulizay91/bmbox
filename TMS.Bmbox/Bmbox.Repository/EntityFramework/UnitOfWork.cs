using Bmbox.Repository.Configuration;
using Bmbox.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Bmbox.Repository.EntityFramework
{
  public class UnitOfWork : IUnitOfWork
  {
    private bool _disposed = false;
    private readonly BmboxContext _context;

    public UnitOfWork(BmboxContext context)
    {
      _context = context;
    }

    private Dictionary<System.Type, object> _repositories;

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : class
    {
      if (_repositories == null)
      {
        _repositories = new Dictionary<System.Type, object>();
      }

      var type = typeof(TEntity);
      if (!_repositories.ContainsKey(type))
      {
        _repositories[type] = new GenericRepository<TEntity, TKey>(_context);
      }

      return (IGenericRepository<TEntity, TKey>)_repositories[type];
    }

    public void Save()
    {
      using (TransactionScope tScope = new TransactionScope())
      {
        _context.SaveChanges();
        tScope.Complete();
      }
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private IAccountRepository _accountRepository;
    private IAccountTypeRepository _accountTypeRepository;
    private IAccountMovieRepository _accountMovieRepository;
    private IAccountTvSeriesRepository _accountTvSeriesRepository;
    private IAccountBookRepository _accountBookRepository;

    public IAccountRepository AccountRepository
    {
      get
      {
        if (_accountRepository == null)
          _accountRepository = new AccountRepository(_context);

        return _accountRepository;
      }
    }

    public IAccountTypeRepository AccountTypeRepository
    {
      get
      {
        if (_accountTypeRepository == null)
          _accountTypeRepository = new AccountTypeRepository(_context);

        return _accountTypeRepository;
      }
    }

    public IAccountMovieRepository AccountMovieRepository
    {
      get
      {
        if (_accountMovieRepository == null)
          _accountMovieRepository = new AccountMovieRepository(_context);

        return _accountMovieRepository;
      }
    }

    public IAccountTvSeriesRepository AccountTvSeriesRepository
    {
      get
      {
        if (_accountTvSeriesRepository == null)
          _accountTvSeriesRepository = new AccountTvSeriesRepository(_context);

        return _accountTvSeriesRepository;
      }
    }

    public IAccountBookRepository AccountBookRepository
    {
      get
      {
        if (_accountBookRepository == null)
          _accountBookRepository = new AccountBookRepository(_context);

        return _accountBookRepository;
      }
    }

  }
}
