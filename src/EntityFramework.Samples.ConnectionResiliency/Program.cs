using EntityFramework.Samples.ConnectionResiliency.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityFramework.Samples.ConnectionResiliency
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<ConnectionResiliencyDbContext>(o =>
            {
                o.UseSqlServer("", options => {
                    options.EnableRetryOnFailure();
                });
            });

            // Service Provider servisleri çözebileceğimiz (resolve) bir containerdır.
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<ConnectionResiliencyDbContext>();
            context.Users.Add(new Shared.Entities.User
            {
                Name = "Cansu"
            });

            context.SaveChanges();
            Console.ReadLine();
        }
    }
}
