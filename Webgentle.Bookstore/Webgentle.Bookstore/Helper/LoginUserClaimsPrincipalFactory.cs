using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Helper
{
  // use claims to store login user data like session
  public class LoginUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<LoginUser, IdentityRole>
  {
    public LoginUserClaimsPrincipalFactory(UserManager<LoginUser> userManager, RoleManager<IdentityRole> roleManager,
      IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(LoginUser user)
    {
      var identity =  await base.GenerateClaimsAsync(user);
      identity.AddClaim(new Claim("userFirstName", user.FirstName));
      identity.AddClaim(new Claim("userLastName", user.LastName));
      return identity;
    }

  }
}
