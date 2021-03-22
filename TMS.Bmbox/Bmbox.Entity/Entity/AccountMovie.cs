using System;
using System.ComponentModel.DataAnnotations;

namespace Bmbox.Entity.Entity
{
  public class AccountMovie : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------

    [Required]
    public int AccountId { get; set; }

    [MaxLength(100)]
    public string ApiId { get; set; }

    [MaxLength(1000)]
    public string Title { get; set; }

    public Nullable<int> Year { get; set; }

    [MaxLength(100)]
    public Nullable<DateTime> ReleaseDate { get; set; }

    [MaxLength]
    public string Genre { get; set; }

    [MaxLength(1500)]
    public string Director { get; set; }

    [MaxLength(1500)]
    public string Writer { get; set; }

    [MaxLength]
    public string Cast { get; set; }

    [MaxLength]
    public string Storyline { get; set; }

    [MaxLength]
    public string Poster { get; set; }

    [MaxLength(100)]
    public string RunTime { get; set; }

    public Nullable<float> Raiting { get; set; }

    public Nullable<int> Votes { get; set; }

    [MaxLength]
    public string Description { get; set; }
  }
}
