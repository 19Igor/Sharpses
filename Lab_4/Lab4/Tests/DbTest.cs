using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace TestProject1;

public class DbTest
{
    // private static readonly string ParentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
    [Test]
    public void CheckDataBaseSaving()
    {
        // string[] expectedData = new string[36]
        // {
        //     "red", "red", "red", "red",
        //     "black", "black", "black", "black",
        //     "red", "red", "red", "red",
        //     "black", "black", "black", "black",
        //     "red", "red", "red", "red",
        //     "black", "black", "black", "black",
        //     "red", "red", "red", "red",
        //     "black", "black", "black", "black",
        //     "red", "red", "red", "red"
        // };
        // EntireDeck entireDeck = new();
        // IDeckShuffler deckShuffler = new DbShuffler();
        // deckShuffler.Shuffle(entireDeck);
        //
        //
        // var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("/Users/igorepov/Documents/Studing/С#Projects/Lab_4/Lab4/Lab4/appsettings.json").Build();
        //
        // var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        // var db = new ApplicationDbContext(optionsBuilder.Options);
        //
        // // var rc = sqlite3_open("filename::memory:");
        //
        // DbWorker dbWorker = new(db);
        // dbWorker.InsertData(entireDeck);
        // List<ExperimentCondition> data = dbWorker.GetData();
        // Console.WriteLine("Список объектов:");
        // foreach (var variable in data)
        // {
        //     for (var i = 0; i < 36; i++)
        //     {
        //         Assert.That(variable.ShellDeck.Cards[i].Color, Is.EqualTo(expectedData[i]));
        //         Console.WriteLine($"card {i + 1} " + variable.ShellDeck.Cards[i].Color);
        //     }
        // }
    }
}
