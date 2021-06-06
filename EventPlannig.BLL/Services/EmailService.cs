using EventPlannig.BLL.Interfaces;
using EventPlannig.BLL.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace EventPlannig.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> option)
        {
            _emailSettings = option.Value;
        }

        public void SendMail(string email, string title, string body)
        {
            // устанавливаем адрес отправителя и получателя
            MailAddress from = new MailAddress(_emailSettings.From);
            MailAddress to = new MailAddress(email);

            // создаем объект сообщения
            var m = new MailMessage(from, to)
            {
                Subject = title,
                Body = body,
                IsBodyHtml = true
            };

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password);
            smtp.EnableSsl = true;

            smtp.Send(m);
        }
    }
}
