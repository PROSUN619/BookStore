using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
  public class SignUpUserModel
  {
    [Required(ErrorMessage = "Please Enter First Name")]
    [Display(Name = "Enter First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please Enter Last Name")]
    [Display(Name = "Enter Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage ="Please Enter Email Address")]
    [Display(Name = "Enter Email Address")]
    [EmailAddress(ErrorMessage ="Not a valid Email Address")]
    public string EmailId { get; set; }
    
    [Required(ErrorMessage = "Please Enter Password")]
    [Display(Name = "Enter Password")]
    [Compare("ConfirmPassword",ErrorMessage ="Password did not match")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please Enter Confirm Password")]
    [Display(Name = "Enter Confirm Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  }
}
