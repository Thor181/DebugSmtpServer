using DebugSmtpServer.Database.Models;
using DebugSmtpServer.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Database.Repositories
{
    public static class BaseRepository<T> where T : class, IEntity
    {
        public static IEnumerable<T> GetAll()
        {
            using var context = new SmtpServerDbContext();
            var entities = context.Set<T>().AsEnumerable().ToImmutableArray();

            return entities;
        }

        public static IEnumerable<T> GetAll(Expression<Func<T, bool>> criteria)
        {
            using var context = new SmtpServerDbContext();

            return context.Set<T>().Where(criteria).ToImmutableArray();
        }
    }
}
