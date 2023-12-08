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
            // так как я не могу кастонуть ACard к ExperimentCondition, поэтому я оставил ExperimentCondition
            // возможно будет ошибка из-за того, что здесь абстрактный класс
            .WithOne(e => e.ExperimentCondition)  
            .HasForeignKey(e => e.ExperimentConditionId);
    }
}




// здесь я добавил
// 1. CardForExperiment(Number, Color, *RefId To ExperimentCondition) - видимо, в таком формате в бд будет представляется
// 2. ExperimentCondition(ID, List<CardsForExperiment>)