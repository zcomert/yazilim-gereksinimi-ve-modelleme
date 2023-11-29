using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
     : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
        .HasData(
            new Employee(){EmployeeId=1, FirstName="Eren", LastName="Güven", Salary=50_000},
            new Employee(){EmployeeId=2, FirstName="İrem", LastName="Bulut", Salary=60_000},
            new Employee(){EmployeeId=3, FirstName="Bahar", LastName="Güneş", Salary=40_000}
        );
    }
}