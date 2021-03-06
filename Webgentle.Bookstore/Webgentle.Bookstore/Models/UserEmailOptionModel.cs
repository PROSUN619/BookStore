using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
  public class UserEmailOptionModel
  {
    public List<string> ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<KeyValuePair<string,string>> PlaceHolder { get; set; }
  }
}
