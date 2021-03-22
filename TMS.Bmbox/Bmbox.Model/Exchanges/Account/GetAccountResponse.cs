using Bmbox.Model.ViewModels.Account;

namespace Bmbox.Model.Exchanges.Account
{
  public class GetAccountResponse : BaseResponse
  {
    public AccountViewModel Account { get; set; }
  }
}
