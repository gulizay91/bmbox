using Bmbox.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Repository.Interface.EntityFramework
{
  public interface IAccountBookRepository : IGenericRepository<AccountBook, int>
  {
    List<AccountBook> AccountBookList(int? AccountId = 0, int? BookId = 0);
    AccountBook GetAccountBookCoupling(int AccountId, int BookId);
  }
}
