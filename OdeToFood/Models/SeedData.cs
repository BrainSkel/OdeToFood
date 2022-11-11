using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using OdeToFood.Models;
using OdeToFood.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
        public static async Task SeedIdentity(UserManager<OdeToFoodUser> userManager, RoleManager<OdeToFoodRole> roleManager)
        {
            var user = userManager.FindByNameAsync("hanne53rik@gmail.com").Result;
            if (user == null)
            {
                user = new OdeToFoodUser();
                user.Email = "hanne53rik@gmail.com";
                user.EmailConfirmed = true;
                user.UserName = "hanne53rik@gmail.com";
                var userResult = await userManager.CreateAsync(user);
                if (!userResult.Succeeded)
                {
                    throw new Exception($"User creation failed: {userResult.Errors.FirstOrDefault()}");
                }
                await userManager.AddPasswordAsync(user, "Pa$$w0rd");
            }
            var role = await roleManager.FindByNameAsync(ROLE_ADMIN);
            if (role == null)
            {
                role = new OdeToFoodRole();
                role.Name = ROLE_ADMIN;
                role.NormalizedName = ROLE_ADMIN;
                var roleResult = roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    throw new Exception(roleResult.Errors.First().Description);
                }
            }
            await userManager.AddToRoleAsync(user, ROLE_ADMIN);

        }
    }
}

