using Bmbox.Entity.Entity;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IAccountRepository : IGenericRepository<Account, int>
  {
    Account GetAccountByUserName(string UserName);
  }
}
