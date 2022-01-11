using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
  public class ChangePasswordModel
  {
    [Required, Display(Name ="Enter Current Password"),DataType(DataType.Password)]
    public string CurrentPassword { get; set; }
    [Required, Display(Name = "Enter New Password"), DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required, Display(Name = "Confirm New Password"),Compare("NewPassword"), DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set; }
  }
}
