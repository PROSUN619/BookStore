using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Services
{
  public interface IEmailService
  {
    Task SendTestEmail(UserEmailOptionModel emailOptionmodel);

    Task SendEmailConfirmation(UserEmailOptionModel emailOptionmodel);
    Task SendEmailForgotPassword(UserEmailOptionModel emailOptionmodel);
  }
}