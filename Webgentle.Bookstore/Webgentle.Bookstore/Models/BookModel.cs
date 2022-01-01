using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Webgentle.Bookstore.Enums;
using Webgentle.Bookstore.Helper;
using Microsoft.AspNetCore.Http;

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
    [Required][Display(Name ="Upload cover photo")]
    public IFormFile CoverPhoto { get; set; }
    public string CoverImageURL { get; set; }
    [Required]
    [Display(Name = "Upload Gallary photo")]
    public IFormFileCollection GallaryFiles { get; set; }
    public List<GallaryModel> Gallary { get; set; }
    [Required]
    [Display(Name = "Upload Book PDF")]
    public IFormFile BookPdf { get; set; }
    public string BookPdfURL { get; set; }

  }
}
