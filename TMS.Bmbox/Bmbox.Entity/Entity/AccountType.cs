using System.ComponentModel.DataAnnotations;

namespace Bmbox.Entity.Entity
{
  public class AccountType : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------

    [Required]
    [MaxLength(10)]
    public string TypeCode { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
  }
}
