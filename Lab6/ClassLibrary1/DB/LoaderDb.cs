using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1.DB;

public class LoaderDb
{
    public static DbInfo LoadDb(int index)
    {
        Console.WriteLine("Это путь " + Directory.GetCurrentDirectory);
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("/Users/igorepov/Documents/Studing/С#Projects/Lab6/Lab6/appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>(); 
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationDbContext(optionsBuilder.Options);
        return new DbInfo(db, index);
    }
}