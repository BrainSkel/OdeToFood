using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using OdeToFood.Models;
using OdeToFood.Data;

namespace OdeToFood.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }

                context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Hello",
                        City = "Elo",
                        Country = "Ameruca"
                    },
                    new Restaurant
                    {
                        Name = "GoodBoy",
                        City = "Arel",
                        Country = "Estoska"
                    }
                );
                context.SaveChanges();

            }
        }
   
    }
}
