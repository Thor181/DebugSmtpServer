using DebugSmtpServer.Database.Models;
using DebugSmtpServer.Web.Models.Mails;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Web.Utils.Mapping
{
    public static class Extensions
    {
        public static MailShortInfo ToMailShortInfo(this Mail mail)
        {
            return new MailShortInfo(mail.Id, mail.Name, mail.Date.ToUnixTimeMilliseconds(), mail.From, mail.Body);
        }
    }
}
