using DebugSmtpServer.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Database.Models
{
    public class Mail : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string[] To { get; set; }
        public DateTimeOffset Date { get; set; }

        private Mail()
        {
        }

        public Mail(string name, string body, string from, string[] to, DateTimeOffset date) : this()
        {
            Name = name;
            Body = body;
            From = from;
            To = to;
            Date = date;
        }

        public void Save()
        {
            using var context = new SmtpServerDbContext();

            context.Update(this);
            context.SaveChanges();
        }
    }
}
