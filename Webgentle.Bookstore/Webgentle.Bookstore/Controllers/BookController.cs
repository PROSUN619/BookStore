using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
  public class BookController : Controller
  {

    private readonly BookRepository _bookModel = null;

    public BookController(BookRepository repository) // this constructor will get asigned when startup.cs load
      // due to dependancy injection
    {
      _bookModel = repository;
    }

    public async Task<ViewResult> GetAllBooks()
    {
      var data =  await _bookModel.GetAllBooks();
      return View(data);

    }

    public async Task<ViewResult> GetBook(int id)
    {
      var data = await _bookModel.GetBook(id);

      return View(data);
    }

    public ViewResult NewBook(bool isSucess = false, int id = 0)
    {
      ViewBag.IsSuccess = isSucess;
      ViewBag.Id = id;
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBook(BookModel model) 
    {
      int id = await _bookModel.AddNewBooks(model);
      if (id > 0)
      {
        return RedirectToAction(nameof(NewBook), new { isSucess = true, id = id });
      }
      return View();
    }

    public List<BookModel> SearchBook(string title, string authorname )
    {
      return _bookModel.SearchBook(title, authorname);
    }
  }
}
