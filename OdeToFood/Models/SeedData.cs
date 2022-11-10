using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using OdeToFood.Models;
using OdeToFood.Data;
using Microsoft.AspNetCore.Identity;

namespace OdeToFood.Models
{
    public static class SeedData
    {
        public const string ROLE_ADMIN = "Admin";
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
                        Name = "SehBuger",
                        City = "Elo",
                        Country = "Ameruca"
                    },
                    new Restaurant
                    {
                        Name = "Good Boy",
                        City = "Arel",
                        Country = "Estoska"
                    }
                );

                for(int i = 0; i < 1000; i++)
                {
                    context.Restaurants.AddRange(
                        new Restaurant
                        {
                            Name = $"{i}",
                            City = "Nowhere",
                            Country = "UaS"
                        });
                }
                context.SaveChanges();
            }
        }
        public static async void SeedIdentity(UserManager<OdeToFoodUser> userManager, RoleManager<OdeToFoodRole> roleManager)
        {
            var user = userManager.FindByNameAsync("hanne53rik@gmail.com").Result;
            if (user == null)
            {
                user = new OdeToFoodUser();
                user.Email = "hanne53rik@gmail.com";
                user.EmailConfirmed = true;
                user.UserName = "hanne53rik@gmail.com";
                var password
            }

        }
    }
}
