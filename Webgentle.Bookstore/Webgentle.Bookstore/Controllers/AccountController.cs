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
        return RedirectToAction("ConfirmEmail", new { email = model.EmailId });
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
    public async Task<IActionResult> Login(LoginModel model, string returnUrl)
    {
      if (ModelState.IsValid)
      {
        var result = await _accountRepository.PasswordSignInAsync(model);
        if (result.Succeeded)
        {
          if (!string.IsNullOrEmpty(returnUrl))
          {
            LocalRedirect(returnUrl);
          }
          //return RedirectToAction("Index", "Home");
        }
        if (result.IsNotAllowed)
          ModelState.AddModelError("", "Please confirm your Email");
        else
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

    [Route("changepassword")]
    public  IActionResult ChangePassword()
    {
      return View();
    }

    [HttpPost("changepassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await _accountRepository.ChangePasswordAsync(model);
        if (result.Succeeded)
        {
          ViewBag.Issuccess = true;
          ModelState.Clear();
          return View();
        }
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }
      return View();
    }

    [HttpGet("email-confirmation")]
    public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
    {

      EmailConfirmModel model = new EmailConfirmModel()
      {
        Email = email,
        IsSent = (email==null) ?false:true
      };
            
      if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
      {
        token = token.Replace(' ', '+');
        var result = await _accountRepository.ConfirmEmailAsync(uid, token);
        if (result.Succeeded)
        {
          model.IsConfirmed = true;
        }
      }

      return View(model);
    }

    [HttpPost("email-confirmation")]
    public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
    {
      var result = await _accountRepository.IsEmailConfirmedAsync(model.Email);
      if (result)
      {
        model.IsConfirmed = result;
        //return View(model);
      }
      else
      {
        ModelState.AddModelError("", "Something went wrong!");
      }
      return View(model);
      //else
      //{
      //  await _accountRepository.GenerateEmailConfirmationTokenAsync()
      //}      
    }
  }
}
