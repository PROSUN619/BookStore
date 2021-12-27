using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      var data = new BookModel() { Language = "English" };
      ViewBag.IsSuccess = isSucess;
      ViewBag.Id = id;
      SetListofLanguage();
      return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBook(BookModel model) 
    {

      //ModelState.AddModelError("","This is custom error");
      if (ModelState.IsValid)
      {
        int id = await _bookModel.AddNewBooks(model);
        if (id > 0)
        {
          return RedirectToAction(nameof(NewBook), new { isSucess = true, id = id });
        }
      }
      ViewBag.IsSuccess = false;
      ViewBag.Id = 0;
      SetListofLanguage();
      return View("NewBook");
    }

    private void SetListofLanguage()
    {
      //ViewBag.Languages = new SelectList(GetListLanguage(), "Id", "Name");
      ViewBag.Languages = GetMultiLanguage();
    }

    private List<LanguageModel> GetListLanguage()
    {
      return new List<LanguageModel>() 
      { 
          new LanguageModel(){Id = 1, Name="English"},
          new LanguageModel(){Id = 2, Name="Hindi"},
          new LanguageModel(){Id = 3, Name="Bengali"}
      };
    }

    private List<SelectListItem> GetMultiLanguage()
    {
      return new List<SelectListItem>()
      {
          new SelectListItem(){ Text = "English", Value = "1"},
          new SelectListItem(){ Text = "Hindi", Value = "2"},
          new SelectListItem(){ Text = "Bengali", Value = "3"},
          new SelectListItem(){ Text = "Urdu", Value = "4"},
          new SelectListItem(){ Text = "Tamil", Value = "5"}
      };
    }

    public List<BookModel> SearchBook(string title, string authorname )
    {
      return _bookModel.SearchBook(title, authorname);
    }
  }
}
