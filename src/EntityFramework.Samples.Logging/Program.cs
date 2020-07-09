using EntityFramework.Samples.Logging.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EntityFramework.Samples.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var services = new ServiceCollection();
            services.AddDbContext<LoggingDbContext>(o =>
            {
                o.UseLoggerFactory(loggerFactory);
                o.UseInMemoryDatabase("LoggingDb");
            });

            // Service Provider servisleri çözebileceğimiz (resolve) bir containerdır.
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<LoggingDbContext>();
            context.Users.Add(new Shared.Entities.User
            {
                Name = "Cansu"
            });

            context.SaveChanges();
            Console.ReadLine();
        }
    }
}
