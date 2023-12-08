

using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.DB;

public class DbWorker
{
    private ApplicationDbContext Db { get; }
    public DbWorker(ApplicationDbContext db)
    {
        Db = db;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands")]
    public void InsertData(EntireDeck entireDeck)
    {
        // var buffer = new ExperimentCondition
        // {
        //     EntireDeck = entireDeck
        // }; 
        // Db.EntireDecks.Add(entireDeck);
        // Db.ExperimentConditions.Add(buffer);
        // Db.SaveChanges();
        // Console.WriteLine("Data was stored succeed");
    }

    public List<ExperimentCondition> GetData()
    {
        // список колод 
        // var data = Db.ExperimentConditions.Include(
        //     experimentCondition => experimentCondition.EntireDeck).ToList();
        // return data;
        return new List<ExperimentCondition>();
    }
}