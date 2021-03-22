using Bmbox.Entity.Entity;
using System.Collections.Generic;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IAccountTvSeriesRepository : IGenericRepository<AccountTvSeries, int>
  {
    List<AccountTvSeries> AccountTvSeriesList(int? AccountId = 0, int? TvSeriesId = 0);
    AccountTvSeries GetAccountTvSeriesCoupling(int AccountId, int TvSeriesId);
  }
}
