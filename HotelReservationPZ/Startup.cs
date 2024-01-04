using HotelReservation.Core.Helpers;
using HotelReservation.EF;
using HotelReservation.Models.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace HotelReservationPZ
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

            services.ConfigureDatabase();
            services.ConfigureServices();
            services.ConfigureRepository();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HotelDBContext>();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            using(var scope = app.ApplicationServices.CreateScope())
            {
                var roleMenager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //var roles = new[] { "Admin", "Employe", "Member" };
                var roles = Enum.GetValues(typeof(EUserType));
                foreach (var role in roles)
                {
                    if (!await roleMenager.RoleExistsAsync(role.ToString()))
                        await roleMenager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userMeganger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string adminEmail = "admin@admin.com";

                string adminPass = "$Test1231";
                if (await userMeganger.FindByEmailAsync(adminEmail) == null)
                {
                    var admin = new IdentityUser();
                    admin.Id = Guid.NewGuid().ToString();
                    admin.UserName = adminEmail;
                    admin.Email = adminEmail;
                    admin.EmailConfirmed = true;
                    await userMeganger.CreateAsync(admin, adminPass);
                    await userMeganger.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
