using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Services;

namespace Webgentle.Bookstore.Repository
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<LoginUser> _userManager;
    private readonly SignInManager<LoginUser> _signInManager;
    private readonly IUserService _userService;

    public AccountRepository(UserManager<LoginUser> userManager, SignInManager<LoginUser> signInManager,
      IUserService userService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _userService = userService;
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

    public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
    {
      string userId = _userService.GetUserId();
      var user = await _userManager.FindByIdAsync(userId);
      return await _userManager.ChangePasswordAsync(user,model.CurrentPassword,model.NewPassword);
    }
  }
}
