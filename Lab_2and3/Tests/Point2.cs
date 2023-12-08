using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Tests.Implementations;

namespace Tests;

public class Point2
{
    [SetUp]
    public void Setup()
    {
        // do something
    }
    
    [Test]
    public void ExpectedOutcomeOfStrategyWithWellMixedDeck()
    {
        IStrategy strategy = new Strategy1();
        Player mark = new("Mark", strategy);
        Player elon = new("Elon", strategy);
        EntireDeck entireDeck = new();
        IDeckShuffler firstHalfByRedShuffler = new FirstHalfByRedShuffler();
        
        firstHalfByRedShuffler.Shuffle(entireDeck);
        entireDeck.Spread(mark.Deck, elon.Deck);
        
        Assert.That(mark.GetCard(elon.SayCard()), Is.EqualTo("red"));
        
    }
}