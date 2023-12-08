using System.Text;
using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Lab4;

class Program
{
    public static void Main(string[] args)
    {
        // {
        //     using var client = new HttpClient();
        //     Deck? deck = new Deck();
        //     int port = 1234;
        //     var json = JsonConvert.SerializeObject(deck);
        //     Console.WriteLine(json);
        //     HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        //     using var response = await client.PostAsync($"http://localhost:{port}/game/getchoice", content);
        //     response.EnsureSuccessStatusCode();
        //     var responseBody = Convert.ToInt32(await response.Content.ReadAsStringAsync());
        // }
        
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
                services.AddScoped<MyHttpClientHandler>();
            }); 
    }
}

