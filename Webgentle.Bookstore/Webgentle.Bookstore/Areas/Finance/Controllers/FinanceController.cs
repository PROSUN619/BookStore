using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Areas.Finance.Controllers
{
  [Area("finance")]
  public class FinanceController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Dashboard()
    {
      return View();
    }
  }
}
