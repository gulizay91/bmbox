using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Model.Exchanges.Account
{
  public class GetAccountRequest : BaseRequest
  {
    public int Id { get; set; }
    public string UserName { get; set; }
  }
}
