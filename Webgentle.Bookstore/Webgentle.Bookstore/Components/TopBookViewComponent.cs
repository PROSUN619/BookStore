using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Components
{
  public class TopBookViewComponent :ViewComponent
  {
    private readonly IBookRepository _bookRepository;

    public TopBookViewComponent(IBookRepository  bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(int count)
    {
      var topBooks = await _bookRepository.GetTopBooksAsync(count);
      return View(topBooks);
    }
  }
}
