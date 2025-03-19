using System.Net;
using System.Net.Mail;

namespace DebugSmtpServer.TestSender;


internal class Program
{
    static void Main(string[] args)
    {
        //var text = File.ReadAllText(@"G:\Downloads\Message17401709691582690206.eml");
        

        while (true)
        {
            
            Console.WriteLine("Click to send..");
            Console.ReadLine();
            Task.Run(() =>
            {
                var message = new MailMessage("sender@m.ru", "receiver@m.ru,receiver2@m.ru", "Тема этого письма" + Random.Shared.Next(100), "<div class=\"9fb23c85464e9ac1WordSection1\">\r\n<p class=\"228bf8a64b8551e1MsoNormal\" style=\"font-family:'calibri' , sans-serif;font-size:11pt;margin:0cm 0cm 0.0001pt 0cm\">&nbsp;</p>\r\n<p class=\"228bf8a64b8551e1MsoNormal\" style=\"font-family:'calibri' , sans-serif;font-size:11pt;margin:0cm 0cm 0.0001pt 0cm\">&nbsp;</p>\r\n<p class=\"228bf8a64b8551e1MsoNormal\" style=\"font-family:'calibri' , sans-serif;font-size:11pt;margin:0cm 0cm 8pt 0cm\"><span style=\"color:black;font-family:'arial' , sans-serif;font-size:10pt\">С уважением,<br>\r\n<b>Торгашин Артём Александрович<br>\r\n</b></span><b><span style=\"color:#ff9900;font-family:'arial' , sans-serif;font-size:5pt\">_____________________________________________________________________________<br>\r\n</span></b><span style=\"color:#ff9900;font-family:'arial' , sans-serif;font-size:3pt\"><br>\r\n</span><span style=\"color:black;font-family:'arial' , sans-serif;font-size:10pt\">Главный специалист по цифровизации<br>\r\nОтдел автоматизации<br>\r\nООО \"РН-КрасноярскНИПИнефть\"<br>\r\nтел.: <span class=\"wmi-callto\">+7 (391) 200-88-30</span> доб. 2859<br>\r\nкорп.: <span class=\"wmi-callto\">86-5345-2859</span><br>\r\nE-mail: <a href=\"mailto:TorgashinAA@knipi.rosneft.ru\" target=\"_blank\" rel=\"noopener noreferrer\">TorgashinAA@knipi.rosneft.ru</a><br>\r\n<br>\r\n</span><span style=\"color:blue;font-family:'arial' , sans-serif;font-size:10pt\"></span></p>\r\n<p class=\"228bf8a64b8551e1MsoNormal\" style=\"font-family:'calibri' , sans-serif;font-size:11pt;margin:0cm 0cm 0.0001pt 0cm\">&nbsp;</p>\r\n</div>");
                var client = new SmtpClient("knipi-drx-dev1", 25) { Credentials = new NetworkCredential("t", "1") };
                client.Send(message);
            });
        }
    }
}
