using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Webgentle.Bookstore.Models;
using Microsoft.Extensions.Configuration;
using Webgentle.Bookstore.Services;

namespace Webgentle.Bookstore.Controllers
{
  public class HomeController : Controller
  {
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public HomeController(IConfiguration configuration, IUserService userService)
    {
      _configuration = configuration;
      _userService = userService;
    }

    [ViewData]
    public string MyProperty { get; set; } // we can also use view data attribute to display file on view page, layout page

    public ViewResult Index()
    {

      string id = _userService.GetUserId();
      bool isAuth = _userService.IsUserAuthenticated();

      //read connection string from appsettings.json[autoseleted development mode from launchsettings.json]
     
     /*Method 1*/ 
      var result1 = _configuration["ConnectionStrings:AuthenticationType"];
      /*Method 2*/
      var result2 = _configuration.GetValue<string>("ConnectionStrings:AuthenticationType");
      /*Method 3*/
      var result3 = _configuration.GetSection("ConnectionStrings").GetValue<string>("AuthenticationType");

      //dynamic data = new ExpandoObject(); // ExpandoObject used to bind dynamic annonymus object into viewbag and display into views
      //data.Id = 1;
      //data.Name = "Prasun";

      //ViewBag.Data = data;
      //ViewBag.Title = "Prasun";
      //ViewBag.Book = new BookModel() {Title = "Sample Book" }; // here we dont need to use ExpandoObject

      //ViewData["bookObject"] = new BookModel() {Title = "html",Author="Harry" };


      MyProperty = "this is viewdata attribute";
      //ViewBag.Title = "Displyed from viewBag";
      return View();
    }
    //[Route("about-us/{id}/test/{name}")]
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
