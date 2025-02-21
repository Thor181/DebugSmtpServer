using System.Net.Mail;

namespace DebugSmtpServer.TestSender;


internal class Program
{
    static void Main(string[] args)
    {
            var message = new MailMessage("sender@m.ru", "receiver@m.ru", "Тема этого письма", "Тело данного <b>письма</b>");
            var client = new SmtpClient("localhost", 25);

        while (true)
        {
            client.Send(message);
            Console.WriteLine("Click to send..");
            Console.ReadLine();
        }
    }
}
