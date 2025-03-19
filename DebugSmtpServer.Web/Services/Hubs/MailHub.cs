using DebugSmtpServer.Database.Repositories;
using DebugSmtpServer.Web.Models.Mails;
using DebugSmtpServer.Web.Utils.Mapping;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Web.Services.Hubs
{
    public interface IMailHub
    {
        public Task ReceiveMails(MailShortInfo[] mailsInfo);
    }

    public class MailHub : Hub<IMailHub>
    {
        public Task<MailShortInfo[]> GetMails()
        {
            var mails = Mails.GetAll().Select(x => x.ToMailShortInfo()).OrderByDescending(x => x.Date).ToArray();

            return Task.FromResult(mails);
        }
    }
}
