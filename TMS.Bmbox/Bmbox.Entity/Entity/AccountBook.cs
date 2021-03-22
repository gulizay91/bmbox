using System;
using System.ComponentModel.DataAnnotations;

namespace Bmbox.Entity.Entity
{
  public class AccountBook : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------

    [Required]
    public int AccountId { get; set; }

    [MaxLength(1000)]
    public string Title { get; set; }

    [MaxLength(100)]
    public Nullable<DateTime> ReleaseDate { get; set; }

    [MaxLength]
    public string Genre { get; set; }

    [MaxLength]
    public string Poster { get; set; }

    [MaxLength(1500)]
    public string Publisher { get; set; }

    [MaxLength(1500)]
    public string Author { get; set; }

    [MaxLength(1500)]
    public string Translator { get; set; }

    public Nullable<int> Page { get; set; }

    public Nullable<float> Raiting { get; set; }

    [MaxLength]
    public string Description { get; set; }
  }
}
