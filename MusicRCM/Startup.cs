using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicRCM.Areas.Identity.Data;
using MusicRCM.Data;
using MusicRCM.Models;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRCM
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
            services.AddDefaultIdentity<MusicUser>(options => options.SignIn.RequireConfirmedAccount = false)
                  .AddEntityFrameworkStores<MusicDBContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //new SpotifyClient(config);
            services.AddSingleton<ISpotifyClient>(new SpotifyClient(SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("5b7bba93ab5a4d87a33c16afeac6960e", "aeddda90a0af4b7f804023a42c85174a"))));
            services.AddDbContext<MusicDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MusicDBContextConnection")));
            //services.AddDbContext<MusicDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("MusicDBContextConnection")));
            //services.AddAntiforgery(options => { options.Cookie.Expiration = TimeSpan.Zero; });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    name: "default",
                    pattern: "{controller=Seed}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
