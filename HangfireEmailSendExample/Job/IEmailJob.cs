using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireEmailSendExample.Job
{
    public interface IEmailJob
    {
        void StartSendEmail();
    }
}
