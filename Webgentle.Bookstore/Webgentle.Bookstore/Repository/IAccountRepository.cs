using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public interface IAccountRepository
  {
    Task<IdentityResult> CreateUserAync(SignUpUserModel model);
  }
}