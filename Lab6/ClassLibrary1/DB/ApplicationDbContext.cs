using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClassLibrary1.DB;
public sealed class ApplicationDbContext : DbContext 
{
    public DbSet<ExperimentCondition> ExperimentConditions => Set<ExperimentCondition>();
    public DbSet<CardForExperiment> Card => Set<CardForExperiment>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
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

public static class DataBaseWorker
{
    public static (List<SpecialCard>, List<SpecialCard>) ReadDataBase(ApplicationDbContext db, int id)
    {
        var one = db.ExperimentConditions
             .Include(experimentCondition => experimentCondition.Cards)
             .FirstOrDefault(e => e.ExperimentConditionId == id);

        return SepareateDeck(ACard2SpecialCard(one!.Cards.ToList()));
    }

    private static List<SpecialCard> ACard2SpecialCard(List<ACard> buff)
    {
        List<SpecialCard> newOne = new();

        foreach (var variable in buff)
        {
            newOne.Add(new SpecialCard(variable.Color));
        }

        return newOne;
    }

    private static (List<SpecialCard>, List<SpecialCard>) SepareateDeck(List<SpecialCard> buff)
    {
        List<SpecialCard> one = new();
        List<SpecialCard> two = new();
        for (int c = 0; c < 18; c++)
        {
            one.Add(new SpecialCard(buff[c].Color));
            two.Add(new SpecialCard(buff[c + 18].Color));
        }

        return (one, two);
    }
}
