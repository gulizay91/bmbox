using Bmbox.Model.ModelRules;
using Bmbox.Model.ViewModels.Account;
using Bmbox.Repository.Interface.EntityFramework;
using Bmbox.Service.Interface;
using Bmbox.Service.Mapping;
using System.Linq;
using System.Text;

namespace Bmbox.Service.Implementation
{
  public class AccountService : BaseService, IAccountService
  {
    public AccountService(IUnitOfWork source) : base(source)
    {

    }

    #region ValitationAndControls
    StringBuilder brokenRules;

    /// <summary>
    /// Model validasyon kontrolu
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    private bool CheckAccountIsValid(AccountViewModel model)
    {
      brokenRules = new StringBuilder();

      if (model.GetBrokenRules().Count() > 0)
      {
        brokenRules.AppendLine("İşlem sırasında bazı değerler eksik: ");

        foreach (BusinessRule businessRule in model.GetBrokenRules())
          brokenRules.AppendLine(businessRule.Rule);

        return false;
      }

      return true;
    }

    /// <summary>
    /// Hesap var/yok kontrolu
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    private bool CheckIfAccountExist(AccountViewModel model)
    {
      var existUserName = _sourceEntity.AccountRepository.GetAccountByUserName(model.UserName);
      var existEmail = _sourceEntity.AccountRepository.GetAccountByUserName(model.Email);
      
      var account = model.Map();

      if (existUserName != null && account.Id != existUserName.Id)
      {
        brokenRules.AppendLine("Girilen kullanıcı adı sistemde mevcut! Farkli bir kullanıcı adı almayı deneyiniz.");
        return false;
      }
      else if (existEmail != null && account.Id != existEmail.Id)
      {
        brokenRules.AppendLine("Mail adresi sistemde mevcut. Eğer şifrenizi unuttuysanız, şifremi unuttum ile yeni bir şifre alabilirsiniz.");
        return false;
      }
      
      return true;
    }
    #endregion

  }
}
