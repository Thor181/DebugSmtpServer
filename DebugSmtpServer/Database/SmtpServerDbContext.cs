using DebugSmtpServer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Database
{
    internal class SmtpServerDbContext : DbContext
    {
        private static bool Initialized = false;

        public virtual DbSet<Mail> Mails { get; set; }

        public SmtpServerDbContext() : base()
        {
            Initialize();
        }

        public SmtpServerDbContext(DbContextOptions op) : base(op)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=mails.db");
        }

        private void Initialize()
        {
            if (!Initialized)
            {
                this.Database.Migrate();
                Initialized = true;
            }
        }
    }
}
