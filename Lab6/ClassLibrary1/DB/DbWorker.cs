using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1.DB;

public static class DbWorker
{
    public static DbInfo LoadDB(int index)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("/Users/igorepov/Documents/Studing/С#Projects/Lab6/Lab6/appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite(configuration.GetConnectionString("ApplicationContext"));
        var db = new ApplicationDbContext(optionsBuilder.Options);
        return new DbInfo(db, index);
    }
}
