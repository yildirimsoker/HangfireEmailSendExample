using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using HangfireEmailSendExample.Setting;

namespace HangfireEmailSendExample.Services
{
    public class EmailService: IEmailService
    {
        private readonly IOptions<MailSettings> _mailSeetings;

        public EmailService(IOptions<MailSettings> mailSeetings)
        {
            _mailSeetings = mailSeetings;
        }

        public void Send()
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.Subject = "Project Info";
                mailMessage.Body = string.Format("Project Running {0}", DateTime.Now.ToString("F"));
                mailMessage.From = new MailAddress(_mailSeetings.Value.EmailAddress);

                string[] toEmailAddress = _mailSeetings.Value.ToMailAddress.Split(";");
                foreach (var toEmail in toEmailAddress)
                    mailMessage.To.Add(toEmail);

                SmtpClient smtp = new SmtpClient(_mailSeetings.Value.MailServer);
                smtp.Credentials = new System.Net.NetworkCredential(_mailSeetings.Value.EmailAddress, _mailSeetings.Value.EmailPassword);
                smtp.Port = _mailSeetings.Value.SmtpPort;
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
            }
        }
    }
}
