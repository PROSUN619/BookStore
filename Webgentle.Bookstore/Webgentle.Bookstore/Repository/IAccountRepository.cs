using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public interface IAccountRepository
  {
    Task<IdentityResult> CreateUserAync(SignUpUserModel model);
    Task<SignInResult> PasswordSignInAsync(LoginModel model);
    Task SignOutAsync();
    Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    Task GenerateEmailConfirmationTokenAsync(LoginUser user);
    Task<bool> IsEmailConfirmedAsync(string email);
    Task GenerateForgotPasswordTokenAsync(LoginUser user);
    Task<LoginUser> GetUserByEmalAsync(string email);
    Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
  }
}