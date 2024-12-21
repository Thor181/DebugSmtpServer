using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer
{
    public class ReceiveMailEventArgs(MimeMessage mail) : EventArgs
    {
        public MimeMessage Mail { get; } = mail;
    }
}
