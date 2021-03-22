using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bmbox.Entity.Entity
{
  public partial class Account : BaseEntity
  {
    public Account()
    {
      AccountMovies = new HashSet<AccountMovie>();
      AccountBooks = new HashSet<AccountBook>();
      AccountTvSeries = new HashSet<AccountTvSeries>();
    }

    //-----------------------------
    //Properties
    //-----------------------------

    [Required]
    public int AccountTypeId { get; set; }

    [Required]
    [MaxLength(20)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(30)]
    public string Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    public DateTime? Birthday { get; set; }

    [MaxLength(45)]
    public string PhoneNumber { get; set; }

    [MaxLength(500)]
    public string Profile { get; set; }

    public byte[] Avatar { get; set; }

    [MaxLength(500)]
    public string AvatarUrlPath { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------

    [ForeignKey("AccountTypeId")]
    public virtual AccountType AccountType { get; set; }

    public virtual ICollection<AccountMovie> AccountMovies { get; set; }
    public virtual ICollection<AccountBook> AccountBooks { get; set; }
    public virtual ICollection<AccountTvSeries> AccountTvSeries { get; set; }
  }
}
