using DebugSmtpServer.Database.Models;
using DebugSmtpServer.Database.Repositories;

namespace DebugSmtpServer.TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var entity = new Mail();
            //entity.Name = "Test2";   
            //entity.Save();
            //entity = new Mail();
            //entity.Id = 1;
            //entity.Name = "Test5";
            //entity.Save();
            var a  = Mails.GetAll().ToArray();
        }
    }
}
