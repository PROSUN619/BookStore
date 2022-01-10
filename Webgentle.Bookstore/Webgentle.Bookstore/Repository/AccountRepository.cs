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

    public AccountRepository(UserManager<LoginUser> userManager)
    {
      _userManager = userManager;
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
  }
}
