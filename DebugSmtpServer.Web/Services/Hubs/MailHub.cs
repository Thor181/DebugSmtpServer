using DebugSmtpServer.Web.Models.Mails;
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
        public Task ReceiveMails(ReadOnlySpan<MailShortInfo> mailsInfo);
    }

    public class MailHub : Hub<IMailHub>
    {

    }
}
