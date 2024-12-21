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

        private readonly MailShortInfo[] _pooledArray;

        public SmtpListener(IHubContext<MailHub, IMailHub> hubContext)
        {
            _pooledArray = new MailShortInfo[1];
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
            _pooledArray[0] = new MailShortInfo(e.Mail.Subject, e.Mail.TextBody);

            _hubContext.Clients.All.ReceiveMails(_pooledArray).GetAwaiter().GetResult();

            _pooledArray[0] = null;
        }
    }
}
