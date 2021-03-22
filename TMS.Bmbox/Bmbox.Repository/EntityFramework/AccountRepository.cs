using Bmbox.Entity.Entity;
using Bmbox.Log;
using Bmbox.Model.Enums;
using Bmbox.Repository.Configuration;
using Bmbox.Repository.Interface.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bmbox.Repository.EntityFramework
{
  public class AccountRepository : GenericRepository<Account, int>, IAccountRepository
  {
    private BmboxContext _context;

    public AccountRepository(BmboxContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public Account GetAccountByUserName(string UserName)
    {
      Account entity = new Account();

      try
      {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        System.Text.RegularExpressions.Match match = regex.Match(UserName);

        //if (UserName.Contains("@") && UserName.Contains("."))
        if (match.Success) // username mail adresi ise mail ile useri getir
          entity = _context.Account
                    .Include(r => r.AccountType)
                  .SingleOrDefault(r => r.IsActive && r.Email == UserName.Trim());
        else
          entity = _context.Account
                    .Include(r => r.AccountType)
                  .SingleOrDefault(r => r.IsActive && r.UserName == UserName.Trim());
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
