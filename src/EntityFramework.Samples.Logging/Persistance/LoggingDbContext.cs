using EntityFramework.Samples.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Samples.Logging.Persistance
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options)
       : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
