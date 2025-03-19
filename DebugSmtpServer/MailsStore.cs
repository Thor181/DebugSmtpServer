using DebugSmtpServer.Database.Models;
using DebugSmtpServer.Database.Repositories;
using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer
{
    internal class MailsStore : MessageStore
    {
        public event EventHandler<ReceiveMailEventArgs> ReceiveMail;

        public override async Task<SmtpResponse> SaveAsync(ISessionContext context, IMessageTransaction transaction, ReadOnlySequence<byte> buffer, CancellationToken cancellationToken)
        {
            await using var stream = new MemoryStream();

            var position = buffer.GetPosition(0);
            while (buffer.TryGet(ref position, out var memory))
            {
                await stream.WriteAsync(memory, cancellationToken);
            }

            stream.Position = 0;

            var message = await MimeKit.MimeMessage.LoadAsync(stream, cancellationToken);
            var from = message.From.Mailboxes.FirstOrDefault()?.Address ?? string.Empty;
            var to = message.To.Mailboxes.Select(x => x.Address).ToArray();
            var mail = new Mail(message.Subject, message.HtmlBody ?? message.TextBody, from, to, message.Date);
            mail.Save();

            var args = new ReceiveMailEventArgs(mail);

            ReceiveMail?.Invoke(this, args);

            return SmtpResponse.Ok;
        }
    }
}
