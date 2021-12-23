using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Controllers
{
  public class HomeController : Controller
  {
    [ViewData]
    public string MyProperty { get; set; } // we can also use view data attribute to display file on view page, layout page

    public ViewResult Index()
    {
      //dynamic data = new ExpandoObject(); // ExpandoObject used to bind dynamic annonymus object into viewbag and display into views
      //data.Id = 1;
      //data.Name = "Prasun";

      //ViewBag.Data = data;
      //ViewBag.Title = "Prasun";
      //ViewBag.Book = new BookModel() {Title = "Sample Book" }; // here we dont need to use ExpandoObject

      ViewData["bookObject"] = new BookModel() {Title = "html",Author="Harry" };


      MyProperty = "this is viewdata attribute";
      return View();
    }

    public ViewResult AboutUs()
    {
      return View();
    }

    public ViewResult ContactUs()
    {
      return View();
    }

  }
}
