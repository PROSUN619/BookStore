using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<LoginUser> _userManager;
    private readonly SignInManager<LoginUser> _signInManager;

    public AccountRepository(UserManager<LoginUser> userManager, SignInManager<LoginUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUserAync(SignUpUserModel model)
    {
      var user = new LoginUser()
      {
        FirstName = model.FirstName,
        LastName = model.LastName,
        Email = model.EmailId,
        UserName = model.EmailId
      };

      var result = await _userManager.CreateAsync(user, model.Password);
      return result;
    }

    public async Task<SignInResult> PasswordSignInAsync(LoginModel model)
    {
     var result = await _signInManager.PasswordSignInAsync(model.EmailId, model.Password, model.RememberMe, false);
      return result;
    }

    public async Task SignOutAsync()
    {
      await _signInManager.SignOutAsync();
    }
  }
}
