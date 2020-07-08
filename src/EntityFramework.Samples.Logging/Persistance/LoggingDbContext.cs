using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Samples.Logging.Persistance
{
    public class LoggingDbContext : DbContext
    {
        private static ILoggerFactory loggerFactory
        {
            get
            {
                return loggerFactory == null ?
                    LoggerFactory.Create(builder => { builder.AddConsole(); }) :
                    loggerFactory;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .UseSqlServer(@"");
        }
    }
}
