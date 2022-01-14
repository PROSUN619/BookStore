using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webgentle.Bookstore.Models
{
  public class ResetPasswordModel
  {
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Token { get; set; }
    [Required, DataType(DataType.Password)]
    public string ResetPassword { get; set; }
    [Required, DataType(DataType.Password),Compare("ResetPassword")]
    public string ConfirmPassword { get; set; }
    public bool IsSuccess { get; set; }
  }
}
