using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
  public class BookController : Controller
  {

    private readonly IBookRepository _bookRepository = null;
    private readonly ILanguageRepository _LanguageRepository = null;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository,
      IWebHostEnvironment webHostEnvironment)
    // this constructor will get asigned when startup.cs load
    // due to dependancy injection
    {
      _bookRepository = bookRepository;
      _LanguageRepository = languageRepository;
      _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ViewResult> GetAllBooks()
    {
      var data = await _bookRepository.GetAllBooks();
      return View(data);

    }

    public async Task<ViewResult> GetBook(int id)
    {
      var data = await _bookRepository.GetBook(id);

      return View(data);
    }

    public async Task<ViewResult> NewBook(bool isSucess = false, int id = 0)
    {
      //var data = new BookModel() { Language = "English" };
      ViewBag.IsSuccess = isSucess;
      ViewBag.Id = id;
      //ViewBag.Languages = await SetListofLanguage();
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBook(BookModel model)
    {

      //ModelState.AddModelError("","This is custom error");
      if (ModelState.IsValid)
      {

        if (model.CoverPhoto != null)
        {
          string folder = "books/cover/";
          model.CoverImageURL = await UploadImage(folder, model.CoverPhoto);
        }

        if (model.GallaryFiles != null)
        {
          string folder = "books/gallary/";
          model.Gallary = new List<GallaryModel>();
          foreach (var file in model.GallaryFiles)
          {
            var gallary = new GallaryModel()
            {
              Name = file.FileName,
              URL = await UploadImage(folder, file)
            };
            model.Gallary.Add(gallary);
          }
        }

        if (model.BookPdf != null)
        {
          string folder = "books/pdf/";
          model.BookPdfURL = await UploadImage(folder, model.BookPdf);
        }

        int id = await _bookRepository.AddNewBooks(model);
        if (id > 0)
        {
          return RedirectToAction(nameof(NewBook), new { isSucess = true, id = id });
        }
      }
      ViewBag.IsSuccess = false;
      ViewBag.Id = 0;
      //ViewBag.Languages = await SetListofLanguage();
      return View("NewBook");
    }

    private async Task<string> UploadImage(string folderPath, IFormFile file)
    {
      folderPath += Guid.NewGuid().ToString() + file.FileName;
      string serverPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
      await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));
      return "/" + folderPath;
    }

    private async Task<SelectList> SetListofLanguage()
    {
      //ViewBag.Languages = new SelectList(GetListLanguage(), "Id", "Name");
      //ViewBag.Languages = GetMultiLanguage();
      return new SelectList(await _LanguageRepository.GetLanguages(), "Id", "Name");
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

    //public List<BookModel> SearchBook(string title, string authorname )
    //{
    //  //return _bookModel.SearchBook(title, authorname);
    //}
  }
}
