using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
  public class LoginModel
  {
    [Required]
    [Display(Name ="Email Id")]
    [EmailAddress]
    public string EmailId { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
  }
}
