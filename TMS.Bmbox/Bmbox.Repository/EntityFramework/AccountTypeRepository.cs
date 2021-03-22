using Bmbox.Entity.Entity;
using Bmbox.Log;
using Bmbox.Model.Enums;
using Bmbox.Repository.Configuration;
using Bmbox.Repository.Interface.EntityFramework;
using System;
using System.Linq;

namespace Bmbox.Repository.EntityFramework
{
  public class AccountTypeRepository : GenericRepository<AccountType, int>, IAccountTypeRepository
  {
    private BmboxContext _context;

    public AccountTypeRepository(BmboxContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public AccountType GetTypeByCode(string TypeCode)
    {
      AccountType entity = new AccountType();

      try
      {
        entity = _context.AccountType
                  .SingleOrDefault(r => r.IsActive && r.TypeCode == TypeCode.Trim());

      }
      catch (Exception ex)
      {
        entity = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entity;
    }
  }
}
