using HangfireEmailSendExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireEmailSendExample.Job
{
    public class EmailJob: IEmailJob
    {
        private readonly IEmailService _emailService;

        public EmailJob(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void StartSendEmail() 
        {
            _emailService.Send();
        }
    }
}
