using EntityFramework.Samples.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Samples.ConnectionResiliency.Persistance
{
    public class ConnectionResiliencyDbContext : DbContext
    {
            public ConnectionResiliencyDbContext(DbContextOptions<ConnectionResiliencyDbContext> options)
           : base(options)
            { }

            public DbSet<User> Users { get; set; }
    }
}
