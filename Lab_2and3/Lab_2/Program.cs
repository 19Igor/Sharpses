using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab_2;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args)        	
    {
        // это является контейнером 
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                
                services.AddHostedService<CollisiumExperimentWorker>();
                services.AddScoped<ICollisiumSandbox, CollisiumSandbox>();
                services.AddScoped<IDeckShuffler, DeckShuffler>();
                services.AddScoped<Player>(_ => new Player("Elon", new Strategy1()));
                services.AddScoped<Player>(_ => new Player("Mark", new Strategy1()));
            }); 
    }
}

