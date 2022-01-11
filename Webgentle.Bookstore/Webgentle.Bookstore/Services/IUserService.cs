namespace Webgentle.Bookstore.Services
{
  public interface IUserService
  {
    string GetUserId();
    bool IsUserAuthenticated();
  }
}