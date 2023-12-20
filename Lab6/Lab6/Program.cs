using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Lab4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab6;

class Program // Starter
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)        	
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((h, services) =>
            {
                services.AddHostedService<ColosseumExperimentWorker>();
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(h.Configuration.GetConnectionString("ApplicationContext"))); 
                services.AddScoped<IСolosseumSandbox, ColosseumDbSandbox>();
                services.AddScoped<IDeckShuffler, SpecialDeckShuffler>();
                services.AddScoped<IEntireDeck, ShellDeck>();
                services.AddScoped<Player>(_ => new Player("Elon", new Strategy1()));
                services.AddScoped<Player>(_ => new Player("Mark", new Strategy1()));
                services.AddHttpClient<MyHttpClientHandler>();
            }); 
    }
}

