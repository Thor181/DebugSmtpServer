using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Web.Models.Mails
{
    public record MailShortInfo(long Id, string Subject, long Date, string From, string Body)
    {
        
    }
}
