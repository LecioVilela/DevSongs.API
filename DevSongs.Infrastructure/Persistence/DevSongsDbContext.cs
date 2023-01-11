using DevSongs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Infrastructure.Persistence
{
    public class DevSongsDbContext : DbContext
    {
        public DevSongsDbContext(DbContextOptions<DevSongsDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
