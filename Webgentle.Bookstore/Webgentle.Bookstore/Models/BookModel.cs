using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Webgentle.Bookstore.Enums;
using Webgentle.Bookstore.Helper;

namespace Webgentle.Bookstore.Models
{
  public class BookModel
  {
    public int Id { get; set; }
    [Required]//[StringLength(maximumLength:20,MinimumLength =5)]
    //[CustomAttribute("angular",ErrorMessage ="Error Message from model")]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public string Category { get; set; }
    [Required(ErrorMessage = "Total pages is missing")]
    [Display(Name = "Total Pages")]
    public int? TotalPages { get; set; }
    [Required][Display(Name = "Select Language")]
    public int LanguageId { get; set; }
    public string Language { get; set; }
    public Language EnumLanguage { get; set; }
    public string Description { get; set; }
  }
}
