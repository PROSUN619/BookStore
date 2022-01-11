using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Services
{
  public class UserService : IUserService
  {
    private readonly IHttpContextAccessor _httpContextAccesor;

    public UserService(IHttpContextAccessor httpContextAccesor)
    {
      _httpContextAccesor = httpContextAccesor;
    }

    public string GetUserId()
    {
      return _httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public bool IsUserAuthenticated()
    {
      return _httpContextAccesor.HttpContext.User.Identity.IsAuthenticated;
    }
  }
}
