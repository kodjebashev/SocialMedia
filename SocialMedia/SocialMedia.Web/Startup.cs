namespace SocialMedia.Web
{
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SocialMedia.Data;
    using SocialMedia.Data.Models;
    using SocialMedia.Services.JSON;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddRazorPages();
            services.AddMvc();

            services
                .AddDbContext<SocialMediaDbContext>(opt => opt
                    .UseSqlServer(Configuration.GetConnectionString("SocialMediaDb")));

            // Fix for CS0246 and CS1929:
            // Ensure the correct DbContext is used and the IdentityBuilder is properly configured.
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SocialMediaDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            services.AddConventionalServices();
            // Add Generic service
            services.AddTransient(typeof(IJsonService<>), typeof(JsonService<>));

            // Cookies for Login
            services
                .ConfigureApplicationCookie(options => options
                    .LoginPath = "/Account/Login");
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.MigrateDatabase();
        }
    }
}
