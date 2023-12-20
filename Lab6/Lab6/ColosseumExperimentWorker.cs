using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using Contracts;
using Lab4;
using Lab4.BusEntity;
using Lab6.BusEntity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Lab6;


public sealed class ColosseumExperimentWorker : BackgroundService // Gods
{
    private readonly IСolosseumSandbox _colosseumDbDbSandbox;
    private readonly IDeckShuffler _deckShuffler;
    private readonly bool _dbMode;
    private const int ExperimentCount = 100;
    public readonly MyHttpClientHandler _HttpClient;
    
    public ColosseumExperimentWorker(
            IСolosseumSandbox colosseumDbSandbox, 
            ApplicationDbContext applicationDbContext,
            IDeckShuffler deckShuffler,
            IConfiguration configuration,
            MyHttpClientHandler myHttpClientHandler)
    {
        _colosseumDbDbSandbox = colosseumDbSandbox;
        _deckShuffler = deckShuffler;
        // _context = applicationDbContext; 
        _dbMode = configuration.GetValue<bool>("DbMode");
        _HttpClient = myHttpClientHandler;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var dbInfo = LoaderDb.LoadDb(1);   
        var busControl = BusController.LoadRabitMQ(_HttpClient, dbInfo);
        
        // запуск шины
        BusController.StartBusControl(busControl);
        Console.WriteLine("The Game is running!");
        
        // шина публикует
        await busControl.Publish(new GetterCompleted());
        DataManeger.Semaphore.WaitOne();
        
        // остановка шины
        BusController.StopBusControl(busControl);
    }
}
