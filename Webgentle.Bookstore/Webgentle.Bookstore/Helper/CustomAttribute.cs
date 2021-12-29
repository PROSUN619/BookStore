using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Helper
{
  public class CustomAttribute : ValidationAttribute
  {
    public CustomAttribute(string text)
    {
      TexttoCheck = text;
    }

    public string TexttoCheck { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
       if (value != null)
      {
        string val = value.ToString();
        if (val.Contains(TexttoCheck))
        {
          return ValidationResult.Success;
        }
      }
      return new ValidationResult(ErrorMessage ?? "Data must contain js");
    }
  }
}
