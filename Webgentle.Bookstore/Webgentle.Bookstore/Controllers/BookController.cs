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

    private readonly BookRepository _bookModel;

    public BookController()
    {
      _bookModel = new BookRepository();
    }

    public ViewResult GetAllBooks()
    {
      var data =  _bookModel.GetAllBooks();
      return View(data);

    }

    public ViewResult GetBook(int id)
    {
      var data = _bookModel.GetBook(id);

      return View(data);
    }

    public ViewResult NewBook()
    {
      return View();
    }

    [HttpPost]
    public ViewResult AddNewBook(BookModel model) 
    {
      return View("NewBook");
    }

    public List<BookModel> SearchBook(string title, string authorname )
    {
      return _bookModel.SearchBook(title, authorname);
    }



  }
}
