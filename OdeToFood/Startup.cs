using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Unobtrusive;
using AspNetCore.Unobtrusive.Ajax;
using OdeToFood.Models;
using Microsoft.Data.SqlClient;

namespace OdeToFood
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddUnobtrusiveAjax();

            services.AddIdentity<OdeToFoodUser,OdeToFoodRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetupAppDataAsync(app, env);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseUnobtrusiveAjax();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "cuisine",
                pattern: "cuisine/{name?}",
                defaults: new
                {
                    controller = "Cuisine",
                    action = "Search"
                });
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }

        private void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using var serviceScope = app
                .ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var userManager = serviceScope
                .ServiceProvider
                .GetService<UserManager<OdeToFoodUser>>();
           using var roleManager = serviceScope
                .ServiceProvider
                .GetService<RoleManager<OdeToFoodRole>>();
            using var context = serviceScope
                .ServiceProvider.GetService<ApplicationDbContext>();

            if (context == null)
            {
                throw new ApplicationException("Problem in services. Can not initialize ApplicationDbContext");
            } while (true)
            {
                try
                {
                    context.Database.OpenConnection();
                    context.Database.CloseConnection();
                    break;
                }
                catch (SqlException e)
                {
                    if (e.Message.Contains("The login failed.")) { break; }
                    System.Threading.Thread.Sleep(1000);
                }

            }

        }
        private async Task SetupAppDataAsync(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var userManager = serviceScope.ServiceProvider.GetService<UserManager<OdeToFoodUser>>();
            using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<OdeToFoodRole>>();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context == null)
            {
                throw new ApplicationException("Problem in services. Can not initialize ApplicationDbContext");
            }
            while (true)
            {
                try
                {
                    context.Database.OpenConnection();
                    context.Database.CloseConnection();
                    break;
                }
                catch (SqlException e)
                {
                    if (e.Message.Contains("The login failed.")) { break; }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            await SeedData.SeedIdentity(userManager, roleManager);
            context.SaveChanges();
        }
    }
}
