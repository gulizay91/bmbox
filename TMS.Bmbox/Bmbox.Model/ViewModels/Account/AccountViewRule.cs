using Bmbox.Model.ModelRules;

namespace Bmbox.Model.ViewModels.Account
{
  public class AccountViewRule
  {
    public static readonly BusinessRule UserNameRequired = new BusinessRule("UserName", "Kullanıcı Adı olmalıdır.");
    public static readonly BusinessRule UserNameMaxLength = new BusinessRule("UserName", "Kullanıcı Adı uzunluğu 100 karakterden fazla olamaz!");
    public static readonly BusinessRule FirstNameRequired = new BusinessRule("FirstName", "Kullanıcının Adı olmalıdır.");
    public static readonly BusinessRule FirstNameMaxLength = new BusinessRule("FirstName", "Kullanıcının Adı uzunluğu 100 karakterden fazla olamaz!");
    public static readonly BusinessRule LastNameRequired = new BusinessRule("LastName", "Kullanıcının Soyadı olmalıdır.");
    public static readonly BusinessRule LastNameMaxLength = new BusinessRule("LastName", "Kullanıcının Soyadı uzunluğu 100 karakterden fazla olamaz!");
    public static readonly BusinessRule EmailRequired = new BusinessRule("Email", "Kullanıcının Emaili olmalıdır.");
    public static readonly BusinessRule EmailMaxLength = new BusinessRule("Email", "Kullanıcının Email uzunluğu 200 karakterden fazla olamaz!");
    public static readonly BusinessRule EmailValid = new BusinessRule("Email", "Email uygun formatta olmalıdır.");
    public static readonly BusinessRule PhoneNumberMaxLength = new BusinessRule("PhoneNumber", " Telefon numarası uzunluğu 20 karakterden fazla olamaz!");
    public static readonly BusinessRule AvatarUrlMaxLength = new BusinessRule("AvatarUrlPath", "Fotoğrafın dosya yolu uzunluğu 2000 karakterden fazla olamaz.");
  }
}
