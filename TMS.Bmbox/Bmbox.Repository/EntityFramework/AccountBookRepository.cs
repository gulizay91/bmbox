using Bmbox.Entity.Entity;
using Bmbox.Log;
using Bmbox.Model.Enums;
using Bmbox.Repository.Configuration;
using Bmbox.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bmbox.Repository.EntityFramework
{
  public class AccountBookRepository : GenericRepository<AccountBook, int>, IAccountBookRepository
  {
    private BmboxContext _context;

    public AccountBookRepository(BmboxContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public AccountBook GetAccountBookCoupling(int AccountId, int BookId)
    {
      AccountBook entity = new AccountBook();

      try
      {
        entity = _context.AccountBook
                  .SingleOrDefault(r => r.IsActive && r.Id == BookId && r.AccountId == AccountId);

      }
      catch (Exception ex)
      {
        entity = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entity;
    }

    public List<AccountBook> AccountBookList(int? AccountId = 0, int? BookId = 0)
    {
      List<AccountBook> entities = new List<AccountBook>();

      try
      {
        entities = _context.AccountBook
                  .Where(r => r.IsActive && (!BookId.HasValue || r.Id == BookId)
                          && (!AccountId.HasValue || r.AccountId == AccountId)).ToList();

      }
      catch (Exception ex)
      {
        entities = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entities;
    }
  }
}
