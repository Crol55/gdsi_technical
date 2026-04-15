
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Data;
public class CompanyDbContext: DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options): 
        base (options) 
    { 
    }

    public DbSet<Company> Companies { get; set; } 
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>( entity => {

            entity.ToTable("COMPANY");

            entity.Property(x => x.Id)
            .ValueGeneratedOnAdd();

            entity.Property(x => x.Name)
            .HasMaxLength(200);
        });


        modelBuilder.Entity<User>(entity => {

            entity.ToTable("USER");

            entity.Property(x => x.UserId)
            .ValueGeneratedOnAdd();
        });
            
    }

}
