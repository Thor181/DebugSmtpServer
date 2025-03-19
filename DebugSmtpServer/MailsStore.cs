using DebugSmtpServer.Database.Models;
using DebugSmtpServer.Database.Repositories;
using MimeKit;
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


            string body = null;

            if (message.HtmlBody != null)
            {
                body = message.HtmlBody;
                var images = message.BodyParts.Where(x => x.ContentType.MediaType == "image");

                foreach (MimePart item in images.Cast<MimePart>())
                {
                    using var ms = new MemoryStream();
                    item.Content.DecodeTo(ms, cancellationToken);
                    var base64 = Convert.ToBase64String(ms.ToArray());
                    body = body.Replace("cid:"+ item.ContentId, "data:" + item.ContentType.MimeType + ";base64, " + base64);
                }
            }

            var from = message.From.Mailboxes.FirstOrDefault()?.Address ?? string.Empty;
            var to = message.To.Mailboxes.Select(x => x.Address).ToArray();
            var mail = new Mail(message.Subject, body ?? message.TextBody, from, to, message.Date);
            mail.Save();

            var args = new ReceiveMailEventArgs(mail);

            ReceiveMail?.Invoke(this, args);

            return SmtpResponse.Ok;
        }
    }
}
