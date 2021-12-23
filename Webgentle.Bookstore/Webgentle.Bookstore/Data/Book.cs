using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Data
{
  public class Book
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int TotalPages { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
  }
}
