using System.Collections.Generic;
using EFGetStarted.Model;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class MyDbContext : DbContext
    {
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Leaf> Leaves { get; set; }
        public DbSet<Component> Components { get; set; }

        public MyDbContext()
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(
                "Host=localhost;Database=experiments;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Leaf>(eb =>
            {
                eb.ToTable("leaves");
                eb.HasOne(x => x.ParentTree)
                    .WithMany();
            });

            modelBuilder.Entity<Tree>(eb =>
            {
                eb.ToTable("trees");
                eb.HasMany(x => x.Components)
                    .WithOne(x => x.ParentTree);
            });
        }
    }
}