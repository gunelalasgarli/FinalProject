using dominospizza.DAL;
using dominospizza.Helpers;
using dominospizza.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza
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
            services.AddControllersWithViews(); 
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));

            });
            services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
            {
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequiredUniqueChars = 1;

                identityOptions.User.RequireUniqueEmail = true;

                identityOptions.Lockout.MaxFailedAccessAttempts = 3;
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                identityOptions.Lockout.AllowedForNewUsers = true;
            }).AddDefaultTokenProviders()
           .AddEntityFrameworkStores<AppDbContext>()
           .AddErrorDescriber<IdentityErrorDescriberAz>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
