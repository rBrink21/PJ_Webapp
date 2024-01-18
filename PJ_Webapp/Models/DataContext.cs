using Microsoft.EntityFrameworkCore;

namespace PJ_Webapp.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Soldier> soldiers { get; set; }
}