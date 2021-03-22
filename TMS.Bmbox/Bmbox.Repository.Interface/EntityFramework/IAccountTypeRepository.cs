using Bmbox.Entity.Entity;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IAccountTypeRepository : IGenericRepository<AccountType, int>
  {
    AccountType GetTypeByCode(string TypeCode);
  }
}
