using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicRCM.Areas.Identity.Data;
using MusicRCM.Models;

namespace MusicRCM.Data
{
    public class MusicDBContext : IdentityDbContext<MusicUser>
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options)
            : base(options)
        {
        }
        public DbSet<Song> Song { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
