using AutoMapper;
using Bmbox.Entity.Entity;
using Bmbox.Model.ViewModels.Account;
using System.Collections.Generic;

namespace Bmbox.Service.Mapping
{
  public static class AccountMap
  {
    
    public static AccountViewModel Map(this Account entity)
    {
      return Mapper.Map<Account, AccountViewModel>(entity);
    }

    public static List<AccountViewModel> Map(this List<Account> entities)
    {
      List<AccountViewModel> response = new List<AccountViewModel>();

      foreach (Account entity in entities)
        response.Add(Map(entity));

      return response;

    }

    public static Account Map(this AccountViewModel entity)
    {
      return Mapper.Map<AccountViewModel, Account>(entity);
    }

    public static List<Account> Map(this List<AccountViewModel> entities)
    {
      List<Account> response = new List<Account>();

      foreach (AccountViewModel entity in entities)
        response.Add(Map(entity));

      return response;
    }
    
  }
}
