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
  public class AccountTvSeriesRepository : GenericRepository<AccountTvSeries, int>, IAccountTvSeriesRepository
  {
    private BmboxContext _context;

    public AccountTvSeriesRepository(BmboxContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public AccountTvSeries GetAccountTvSeriesCoupling(int AccountId, int TvSeriesId)
    {
      AccountTvSeries entity = new AccountTvSeries();

      try
      {
        entity = _context.AccountTvSeries
                  .SingleOrDefault(r => r.IsActive && r.Id == TvSeriesId && r.AccountId == AccountId);

      }
      catch (Exception ex)
      {
        entity = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entity;
    }

    public List<AccountTvSeries> AccountTvSeriesList(int? AccountId = 0, int? TvSeriesId = 0)
    {
      List<AccountTvSeries> entities = new List<AccountTvSeries>();

      try
      {
        entities = _context.AccountTvSeries
                  .Where(r => r.IsActive && (!TvSeriesId.HasValue || r.Id == TvSeriesId)
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
