using Microsoft.EntityFrameworkCore;

namespace PJ_Webapp.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Soldier> soldiers { get; set; }
    public DbSet<Skill> skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Soldier>()
            .HasMany(s => s.skills)
            .WithOne(s => s.soldier)
            .HasForeignKey(s => s.soldierId);
    }
}