using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webgentle.Bookstore.Models
{
  public class BookModel
  {
    public int Id { get; set; }
    [Required][StringLength(maximumLength:20,MinimumLength =5)]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public string Category { get; set; }
    [Required(ErrorMessage = "Total pages is missing")]
    [Display(Name = "Total Pages")]
    public int? TotalPages { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
  }
}
