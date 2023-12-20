using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Lab4;

// закоментить удаление бд 
// поменять флог в конфиге

public sealed class ColosseumExperimentWorker : BackgroundService
{
    private readonly IСolosseumSandbox _colosseumDbDbSandbox;
    private int _successOutcomeAmount;
    private readonly ApplicationDbContext _context;
    private readonly IDeckShuffler _deckShuffler;
    private readonly bool _dbMode;
    
    public ColosseumExperimentWorker(
            IСolosseumSandbox colosseumDbSandbox, 
            ApplicationDbContext applicationDbContext,
            IDeckShuffler deckShuffler,
            ApplicationDbContext context,
            IConfiguration configuration)
    {
        _colosseumDbDbSandbox = colosseumDbSandbox;
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
                    await _context.SaveChangesAsync(stoppingToken);
                    _colosseumDbDbSandbox.SetEntireDeck(entireDeck);
                    
                    _successOutcomeAmount += await _colosseumDbDbSandbox.Experiment();
                }
                else
                {
                    var entireDeck = new ShellDeck();
                    var one = _context.ExperimentConditions
                        .Include(experimentCondition => experimentCondition.Cards)
                        .FirstOrDefault(e => e.ExperimentConditionId == index + 1);
                    var two = _context.Card.Where(card => card.ExperimentConditionId == 1).ToList();
                    
                    Debug.Assert(one != null, nameof(one) + " != null");
                    entireDeck.Cards = one.Cards.ToList();
                    
                    _colosseumDbDbSandbox.SetEntireDeck(entireDeck);
                    _successOutcomeAmount += await _colosseumDbDbSandbox.Experiment();
                }
            }
            
            Console.WriteLine("Amount of same cards: " + _successOutcomeAmount);
            Console.WriteLine("Result: " + _successOutcomeAmount / count * 100 + "%");
            _successOutcomeAmount = 0;

            break;
        }
    }
}
