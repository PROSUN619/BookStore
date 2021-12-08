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

    public List<BookModel> GetAllBook()
    {
      return _bookModel.GetAllBooks();
    }

    public BookModel GetBook(int id)
    {
      return _bookModel.GetBook(id);
    }

    public List<BookModel> SearchBook(string bookname, string authorname )
    {
      return _bookModel.SearchBook(bookname, authorname);
    }

  }
}
