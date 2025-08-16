using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace prjFinalProjectApi.Helpers
{
    public sealed class EmailSender
    {
        private readonly IConfiguration _cfg;
        public EmailSender(IConfiguration cfg) { _cfg = cfg; }

        public async Task SendAsync(string to, string subject, string htmlBody)
        {
            var host = _cfg["Smtp:Host"];
            var port = int.Parse(_cfg["Smtp:Port"] ?? "587");
            var account = _cfg["Smtp:Account"];
            var password = _cfg["Smtp:Password"];
            var fromName = _cfg["Smtp:FromName"] ?? "Nursing Home";

            using var client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(account, password)
            };
            var msg = new MailMessage
            {
                From = new MailAddress(account!, fromName),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };
            msg.To.Add(to);
            await client.SendMailAsync(msg);
        }
    }
}
