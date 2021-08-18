using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireEmailSendExample.Setting
{
    public class MailSettings
    {
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string MailServer { get; set; }
        public int SmtpPort { get; set; }
        public string ToMailAddress { get; set; }
    }
}
