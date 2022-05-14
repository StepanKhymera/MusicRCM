using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRCM.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options): base(options)
        {

        }

        public DbSet<Song> Song { get; set; }
        public DbSet<Playlist> Playlist { get; set; }

    }

}
