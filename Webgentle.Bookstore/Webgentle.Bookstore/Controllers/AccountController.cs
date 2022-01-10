using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
  public class AccountController : Controller
  {
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    [Route("signup")]
    public IActionResult SignUp()
    {
      return View();
    }

    [Route("signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpUserModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await _accountRepository.CreateUserAync(model);
        if (!result.Succeeded)
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
        ModelState.Clear();
      }
      return View();
    }

    [Route("login")]
    public IActionResult Login()
    {
      return View();
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await _accountRepository.PasswordSignInAsync(model);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("","Invalid Credential");
      }
      return View();
    }

    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
      await _accountRepository.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

  }
}
