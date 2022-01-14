using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Services
{
  public class EmailService : IEmailService
  {
    private const string templatePath = @"EmailTemplate/{0}.html";
    private readonly SMTPConfigModel _smtpConfig;

    public EmailService(IOptions<SMTPConfigModel> smtpConfig)
    {
      _smtpConfig = smtpConfig.Value;
    }

    public async Task SendTestEmail(UserEmailOptionModel emailOptionmodel)
    {
      emailOptionmodel.Subject = "Test email subject from book store application";
      emailOptionmodel.Body = UpdatePLaceHolder(GetEmailBody("TestEmail"),emailOptionmodel.PlaceHolder);
      await SendEmail(emailOptionmodel);
    }

    public async Task SendEmailConfirmation(UserEmailOptionModel emailOptionmodel)
    {
      emailOptionmodel.Subject = "PLease confirm your email";
      emailOptionmodel.Body = UpdatePLaceHolder(GetEmailBody("EmailConfirm"), emailOptionmodel.PlaceHolder);
      await SendEmail(emailOptionmodel);
    }

    public async Task SendEmailForgotPassword(UserEmailOptionModel emailOptionmodel)
    {
      emailOptionmodel.Subject = "PLease restore your email";
      emailOptionmodel.Body = UpdatePLaceHolder(GetEmailBody("ForgotPassword"), emailOptionmodel.PlaceHolder);
      await SendEmail(emailOptionmodel);
    }

    private async Task SendEmail(UserEmailOptionModel emailOptionmodel)
    {
      MailMessage mail = new MailMessage()
      {
        Subject = emailOptionmodel.Subject,
        Body = emailOptionmodel.Body,
        From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
        IsBodyHtml = _smtpConfig.IsBodyHTML
      };

      foreach (var toemail in emailOptionmodel.ToEmail)
      {
        mail.To.Add(toemail);
      }

      NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

      SmtpClient smtpClient = new SmtpClient()
      {
        Host = _smtpConfig.Host,
        Port = _smtpConfig.Port,
        EnableSsl = _smtpConfig.EnableSSL,
        UseDefaultCredentials = _smtpConfig.UserDefaultCredential,
        Credentials = networkCredential
      };

      mail.BodyEncoding = Encoding.Default;
      await smtpClient.SendMailAsync(mail);
    }

    private string GetEmailBody(string templateName)
    {
      var body = File.ReadAllText(string.Format(templatePath, templateName));
      return body;
    }

    private string UpdatePLaceHolder(string text, List<KeyValuePair<string,string>> placeholder)
    {
      if (!string.IsNullOrEmpty(text) && placeholder != null)
      {
        foreach (var item in placeholder)
        {
          if (text.Contains(item.Key))
          {
            text = text.Replace(item.Key, item.Value);
          }
        }
      }
      return text;
    }
  }
}
