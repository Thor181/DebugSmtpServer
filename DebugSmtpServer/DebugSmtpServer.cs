using SmtpServer;
using SmtpServer.ComponentModel;
using SmtpServer.Storage;

namespace DebugSmtpServer;

public class DebugSmtpServer
{
    private readonly SmtpServer.SmtpServer _server;

    public event EventHandler<ReceiveMailEventArgs> ReceivedMail;

    public DebugSmtpServer()
    {
        var op = new SmtpServerOptionsBuilder().ServerName("SmtpServer").Port(25).Build();

        var store = new MailsStore();
        store.ReceiveMail += HandleReceiveMail;

        var provider = new ServiceProvider();
        provider.Add(store);

        _server = new SmtpServer.SmtpServer(op, provider);
    }

    private void HandleReceiveMail(object? sender, ReceiveMailEventArgs e)
    {
        ReceivedMail?.Invoke(sender, e);
    }

    public async Task ListenAsync(CancellationToken cancellationToken)
    {
        await _server.StartAsync(cancellationToken);
    }
}
