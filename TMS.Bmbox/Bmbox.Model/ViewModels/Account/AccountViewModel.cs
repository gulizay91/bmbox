using Bmbox.Model.ModelRules;
using System;

namespace Bmbox.Model.ViewModels.Account
{
  public class AccountViewModel : ModelBase
  {
    public int Id { get; set; }

    public int AccountTypeId { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public Nullable<DateTime> Birthday { get; set; }

    public string PhoneNumber { get; set; }

    public string Profile { get; set; }

    public string Profession { get; set; }

    public byte[] Avatar { get; set; }

    public string AvatarUrlPath { get; set; }

    public bool IsActive { get; set; }

    /*
    public AccountTypeViewModel AccountType { get; set; }

    public List<AccountMovieViewModel> AccountMovies { get; set; }
    
    public List<View_AccountMovieViewModel> MovieList { get; set; }
    */

    protected override void Validate()
    {

      if (String.IsNullOrEmpty(this.UserName))
        base.AddBrokenRule(AccountViewRule.UserNameRequired);

      if (!String.IsNullOrEmpty(this.UserName) && this.UserName.Length > 100)
        base.AddBrokenRule(AccountViewRule.UserNameMaxLength);

      if (String.IsNullOrEmpty(this.FirstName))
        base.AddBrokenRule(AccountViewRule.FirstNameRequired);

      if (!String.IsNullOrEmpty(this.FirstName) && this.FirstName.Length > 100)
        base.AddBrokenRule(AccountViewRule.FirstNameMaxLength);

      if (String.IsNullOrEmpty(this.LastName))
        base.AddBrokenRule(AccountViewRule.LastNameRequired);

      if (!String.IsNullOrEmpty(this.LastName) && this.LastName.Length > 100)
        base.AddBrokenRule(AccountViewRule.LastNameMaxLength);

      if (String.IsNullOrEmpty(this.Email))
        base.AddBrokenRule(AccountViewRule.EmailRequired);

      if (!String.IsNullOrEmpty(this.Email) && this.Email.Length > 200)
        base.AddBrokenRule(AccountViewRule.EmailMaxLength);

      //if (String.IsNullOrEmpty(this.PhoneNumber))
      //  base.AddBrokenRule(AccountViewRule.PhoneNumberRequired);

      if (!String.IsNullOrEmpty(this.PhoneNumber) && this.PhoneNumber.Length > 20)
        base.AddBrokenRule(AccountViewRule.PhoneNumberMaxLength);

      if (!String.IsNullOrEmpty(this.AvatarUrlPath) && this.AvatarUrlPath.Length > 2000)
        base.AddBrokenRule(AccountViewRule.AvatarUrlMaxLength);


      System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
      System.Text.RegularExpressions.Match match = regex.Match(this.Email);
      if (!String.IsNullOrEmpty(this.Email) && !match.Success)
        base.AddBrokenRule(AccountViewRule.EmailValid);
    }
  }
}
