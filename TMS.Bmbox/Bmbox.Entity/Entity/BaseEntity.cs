using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bmbox.Entity.Entity
{
  public abstract class BaseEntity
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string CreatedBy { get; set; }

    [MaxLength(20)]
    public string UpdatedBy { get; set; }

    private bool? _isActive;

    [Required]
    public bool IsActive
    {
      get
      {
        if (_isActive == null)
        {
          _isActive = false;
        }
        return (bool)_isActive;
      }

      set { _isActive = value; }
    }

    [Required]
    public DateTime CreatedDatetime { get; set; }

    public DateTime? UpdatedDatetime { get; set; }
  }
}
