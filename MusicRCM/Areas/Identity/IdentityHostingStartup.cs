using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicRCM.Areas.Identity.Data;
using MusicRCM.Data;

[assembly: HostingStartup(typeof(MusicRCM.Areas.Identity.IdentityHostingStartup))]
namespace MusicRCM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MusicDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MusicDBContextConnection")));

                services.AddDefaultIdentity<MusicUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<MusicDBContext>();
            });
        }
    }
}