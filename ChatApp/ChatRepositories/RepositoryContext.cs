using ChatEntities;
using Microsoft.EntityFrameworkCore;

namespace ChatRepositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) :
    base(options)
    {
    }

    public DbSet<Chats> Chats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
        .Entity<Chats>()
        .HasData(
            new Chats() { Id = 1, Username = "admin", Message = "test" }
            );
    }
}
