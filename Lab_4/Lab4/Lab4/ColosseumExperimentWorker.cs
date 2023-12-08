using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Lab4;

// закомеетить удаление бд 
// поменять флоа в конфиге

public sealed class ColosseumExperimentWorker : BackgroundService
{
    private readonly IСolosseumSandbox _colosseumDbSandbox;
    private int _successOutcomeAmount;
    private readonly ApplicationDbContext _context;
    private readonly IDeckShuffler _deckShuffler;
    private readonly bool _dbMode;
    
    public ColosseumExperimentWorker(
            IСolosseumSandbox colosseumSandbox, 
            ApplicationDbContext applicationDbContext,
            IDeckShuffler deckShuffler,
            ApplicationDbContext context,
            IConfiguration configuration)
    {
        _colosseumDbSandbox = colosseumSandbox;
        _deckShuffler = deckShuffler;
        _context = applicationDbContext;
        _context = context;
        _dbMode = configuration.GetValue<bool>("DbMode");
    }
    
    [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 100")]
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const double count = 100;
        while (!stoppingToken.IsCancellationRequested)
        {
            for (int index = 0; index < count; index++)
            {
                if (_dbMode) 
                {
                    var entireDeck = new ShellDeck();  // public List<ACard> Cards
                    _deckShuffler.Shuffle(entireDeck);

                    _context.ExperimentConditions.Add(new ExperimentCondition(entireDeck.Cards)); // List<ACard>
                    _context.SaveChanges();
                    _colosseumDbSandbox.SetEntireDeck(entireDeck);
                    _successOutcomeAmount += _colosseumDbSandbox.Experiment();
                }
                else
                {
                    var entireDeck = new ShellDeck();
                    var one = _context.ExperimentConditions.Include(experimentCondition => experimentCondition.Cards)
                        .FirstOrDefault(e => e.ExperimentConditionId == index + 1);
                    
                    Debug.Assert(one != null, nameof(one) + " != null");
                    entireDeck.Cards = one.Cards.ToList();
                    
                    _colosseumDbSandbox.SetEntireDeck(entireDeck);
                    _successOutcomeAmount += _colosseumDbSandbox.Experiment();
                }
            }
            
            Console.WriteLine("Amount of same cards: " + _successOutcomeAmount);
            Console.WriteLine("Result: " + _successOutcomeAmount / count * 100 + "%");
            _successOutcomeAmount = 0;

            break;
            
            // await Task.Delay(5_000, stoppingToken);
        }
    }

    private void PrintEntre(List<ExperimentCondition> allEntries)
    {
        foreach (var variable in allEntries)
        {
            int counter = 0;
            Console.WriteLine($"Experiment number: {variable.ExperimentConditionId}");
            foreach (var card in variable.Cards)
            {
                counter++;
                Console.WriteLine($"Cards {counter}: {card.Color}");
            }
            Console.WriteLine("==================== Empty String ====================");
        }
    }
    
}
