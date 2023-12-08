using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.DB;
public sealed class ApplicationDbContext : DbContext 
{
    public DbSet<ExperimentCondition> ExperimentConditions => Set<ExperimentCondition>();
    public DbSet<CardForExperiment> Card => Set<CardForExperiment>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExperimentCondition>()
            .HasMany(d => d.Cards)
            .WithOne(e => e.ExperimentCondition)  
            .HasForeignKey(e => e.ExperimentConditionId);
    }
}
