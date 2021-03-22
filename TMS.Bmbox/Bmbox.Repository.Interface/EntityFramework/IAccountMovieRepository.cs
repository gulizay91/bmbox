using Bmbox.Entity.Entity;
using System.Collections.Generic;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IAccountMovieRepository : IGenericRepository<AccountMovie, int>
  {
    List<AccountMovie> AccountMovieList(int? AccountId = 0, int? MovieId = 0);
    AccountMovie GetAccountMovieCoupling(int AccountId, int MovieId);
  }
}
