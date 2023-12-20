using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Services;

public class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Items>()
        .HasOne(i => i.Category)
        .WithMany(c => c.FoodItems)
        .HasForeignKey(i => i.CategoryId);

        modelBuilder.Entity<Categories>().HasData(new Categories()
        {
            Id = 1,
            Name = "Soup"
        });
    }
}