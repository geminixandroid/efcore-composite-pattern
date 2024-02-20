using EFGetStarted.Model;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted;

public class ComponentsDbContext : DbContext
{
    public ComponentsDbContext()
    {
        base.Database.EnsureDeleted();
        base.Database.EnsureCreated();
    }

    public DbSet<Tree> Trees { get; set; }

    public DbSet<Leaf> Leaves { get; set; }

    public DbSet<ComponentBase> Components { get; set; }

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
            eb.HasOne(leaf => leaf.ParentTree)
                .WithMany();
        });

        modelBuilder.Entity<Tree>(eb =>
        {
            eb.ToTable("trees");
            eb.HasMany(tree => tree.Components)
                .WithOne(x => x.ParentTree);
        });
    }
}