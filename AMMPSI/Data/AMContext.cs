using AMMPSI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Data
{
    public class AMContext : DbContext
    {
        public AMContext(DbContextOptions<AMContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<MovementItem> MovementItem { get; set;}
        public DbSet<MovementLog> MovementLog { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(m => m.ID);
            builder.Entity<Asset>().HasKey(m => m.ID);
            builder.Entity<Location>().HasKey(m => m.ID);
            builder.Entity<Movement>().HasKey(m => m.ID);
            builder.Entity<MovementItem>().HasKey(m => m.ID);
            builder.Entity<MovementLog>().HasKey(m => m.ID);

            base.OnModelCreating(builder);

        }
    }
}
