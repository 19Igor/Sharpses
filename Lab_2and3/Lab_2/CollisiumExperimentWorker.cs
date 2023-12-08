using System.Diagnostics.CodeAnalysis;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Microsoft.Extensions.Hosting;

namespace Lab_2;

public sealed class CollisiumExperimentWorker : BackgroundService
{
    private readonly ICollisiumSandbox _collisiumSandbox;
    private readonly IDeckShuffler _deckShuffler;
    private readonly Player _mark;
    private readonly Player _elon;
    
    private int _successOutcomeAmount;
    
    public CollisiumExperimentWorker(ICollisiumSandbox collisiumSandbox, 
        IDeckShuffler deckShuffler, IEnumerable<Player> players)
    {
        _collisiumSandbox = collisiumSandbox;
        _deckShuffler = deckShuffler;
        var enumerable = players.ToList();
        _elon = enumerable.ElementAt(0);
        _mark = enumerable.ElementAt(1);

    }
    
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: XoshiroImpl")]
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // const double count = 1000000;
        const double count = 10000;
        while (!stoppingToken.IsCancellationRequested)
        {
            for (int i = 0; i < count; i++)
            {
                _successOutcomeAmount += _collisiumSandbox.Experiment(_mark, _elon, _deckShuffler);
            }
            
            Console.WriteLine("Amount of same cards: " + _successOutcomeAmount);
            Console.WriteLine("Result: " + _successOutcomeAmount / count * 100 + "%");
            _successOutcomeAmount = 0;
            
            await Task.Delay(1_000, stoppingToken);
        }
    }
}
