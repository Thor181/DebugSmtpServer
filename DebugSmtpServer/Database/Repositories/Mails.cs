using DebugSmtpServer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Database.Repositories
{
    public static class Mails
    {
        public static IEnumerable<Mail> GetAll()
        {
            return BaseRepository<Mail>.GetAll();
        }

        public static IEnumerable<Mail> GetAll(Expression<Func<Mail, bool>> criteria)
        {
            return BaseRepository<Mail>.GetAll(criteria);
        }
    }
}
