using DebugSmtpServer.Web.Models.Mails;
using DebugSmtpServer.Web.Services.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Web.Services.SmtpListener
{
    public class SmtpListener : BackgroundService
    {
        private readonly IHubContext<MailHub, IMailHub> _hubContext;
        private readonly DebugSmtpServer _server;

        public SmtpListener(IHubContext<MailHub, IMailHub> hubContext)
        {
            _hubContext = hubContext;
            _server = new DebugSmtpServer();
            _server.ReceivedMail += HandleMailReceive;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = _server.ListenAsync(stoppingToken);

            return Task.CompletedTask;
        }

        private void HandleMailReceive(object? sender, ReceiveMailEventArgs e)
        {
            var mail = e.Mail;
            var shortInfo = new MailShortInfo(1, mail.Subject, mail.Date.ToUnixTimeMilliseconds(), mail.From.Mailboxes.FirstOrDefault().Address, mail.HtmlBody);
            //ReadOnlySpan<MailShortInfo> mails = [shortInfo];

            _hubContext.Clients.All.ReceiveMails([shortInfo]).GetAwaiter().GetResult();
        }
    }
}
