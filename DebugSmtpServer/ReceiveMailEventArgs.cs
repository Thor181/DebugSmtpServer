using DebugSmtpServer.Database.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer
{
    public class ReceiveMailEventArgs(Mail mail) : EventArgs
    {
        public Mail Mail { get; } = mail;
    }
}
