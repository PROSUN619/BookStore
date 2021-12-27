﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Data
{
  public class Language
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Book> Books { get; set; } // realtion between book and language
  }
}
