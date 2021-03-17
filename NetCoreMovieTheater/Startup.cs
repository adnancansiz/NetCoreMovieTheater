using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Repositories;

namespace NetCoreMovieTheater
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //context
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("Server=DESKTOP-QR4J7JA\\SQLEXPRESS;Database=MovieTheaterDb;Trusted_Connection=True;"));

            //Identity
            services.AddIdentity<AppUser, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequiredLength = 5;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();//yetki doðrulama
            app.UseAuthorization();//yetki

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
