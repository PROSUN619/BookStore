using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public AccountRepository(UserManager<LoginUser> userManager, SignInManager<LoginUser> signInManager,
      IUserService userService, IEmailService emailService, IConfiguration configuration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _userService = userService;
      _emailService = emailService;
      _configuration = configuration;
    }

    public async Task<bool> IsEmailConfirmedAsync(string email)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user != null)
        return await _userManager.IsEmailConfirmedAsync(user);
      else
        return false;
    }

    public async Task<LoginUser> GetUserByEmalAsync(string email)
    {
      return await _userManager.FindByEmailAsync(email);
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
      if (result.Succeeded)
      {
        await GenerateEmailConfirmationTokenAsync(user);
      }
      return result;
    }

    public async Task GenerateEmailConfirmationTokenAsync(LoginUser user)
    {
      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
      if (!string.IsNullOrEmpty(token))
      {
        await SendEmailConfirmationToken(user, token);
      }
    }

    public async Task GenerateForgotPasswordTokenAsync(LoginUser user)
    {
      var token = await _userManager.GeneratePasswordResetTokenAsync(user);
      if (!string.IsNullOrEmpty(token))
      {
        await SendForgotPasswordToken(user, token);
      }
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

    public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
    {
      return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
    }

    public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
    {
      return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.ConfirmPassword);
    }


    private async Task SendEmailConfirmationToken(LoginUser user, string token)
    {
     string appDomain =  _configuration.GetSection("Application:AppDomain").Value;
     string emailconfirmation =  _configuration.GetSection("Application:EmailConfirmation").Value;

      UserEmailOptionModel userEmailOptionModel = new UserEmailOptionModel()
      {
        ToEmail = new List<string>() { user.Email },
        PlaceHolder = new List<KeyValuePair<string, string>>()
        {
          new KeyValuePair<string, string>("{{User}}",user.FirstName),
          new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+emailconfirmation,user.Id,token))
        }
      };

      await _emailService.SendEmailConfirmation(userEmailOptionModel);
    }

    private async Task SendForgotPasswordToken(LoginUser user, string token)
    {
      string appDomain = _configuration.GetSection("Application:AppDomain").Value;
      string emailconfirmation = _configuration.GetSection("Application:ForgotPassword").Value;

      UserEmailOptionModel userEmailOptionModel = new UserEmailOptionModel()
      {
        ToEmail = new List<string>() { user.Email },
        PlaceHolder = new List<KeyValuePair<string, string>>()
        {
          new KeyValuePair<string, string>("{{User}}",user.FirstName),
          new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+emailconfirmation,user.Id,token))
        }
      };

      await _emailService.SendEmailForgotPassword(userEmailOptionModel);
    }



  }
}
