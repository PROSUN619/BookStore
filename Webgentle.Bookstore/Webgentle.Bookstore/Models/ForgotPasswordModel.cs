using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
  public class ForgotPasswordModel
  {
    [Required, EmailAddress,Display(Name ="Please Enter your Email Id")]
    public string Email { get; set; }
    public bool EmailSent { get; set; }
  }
}
