using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Tests.Implementations;

namespace Tests;

public class Point4
{
    [SetUp]
    public void Setup()
    {
        // do something
    }

    [Test]
    public void CheckExpectedResultFirstHalfRedSecondBlack()
    {
        var successOutcomeAmount1 = 0;
        const double count = 10000;
        ICollisiumSandbox coliseumSandbox1 = new CollisiumSandbox();
        IDeckShuffler deckShuffler1 = new FirstHalfRedSecondBlack();
        var mark1 = new Player("Mark", new Strategy1());
        var elon1 = new Player("Elon", new Strategy1());
        
        successOutcomeAmount1 += coliseumSandbox1.Experiment(mark1, elon1, deckShuffler1);
        
        Assert.That(successOutcomeAmount1, Is.EqualTo(0));
    }

    [Test]
    public void CheckExpectedResultFirstHalfBlackSecondRed()
    {
        const double count = 10000;
        ICollisiumSandbox coliseumSandbox2 = new CollisiumSandbox();
        IDeckShuffler deckShuffler2 = new FirstHalfBlackSecondRed();
        var mark2 = new Player("Mark", new Strategy1());
        var elon2 = new Player("Elon", new Strategy1());
        var successOutcomeAmount2 = 0;
        
        successOutcomeAmount2 += coliseumSandbox2.Experiment(mark2, elon2, deckShuffler2);

        Assert.That(successOutcomeAmount2, Is.EqualTo(0));
    }

    [Test]
    public void CheckExpectedResultFullRedDeck()
    {
        const double count = 10000;
        ICollisiumSandbox coliseumSandbox3 = new CollisiumSandbox();
        IDeckShuffler deckShuffler3 = new FullRedDeck();
        var mark3 = new Player("Mark", new Strategy1());
        var elon3 = new Player("Elon", new Strategy1());
        var successOutcomeAmount3 = 0;
        
        successOutcomeAmount3 = coliseumSandbox3.Experiment(mark3, elon3, deckShuffler3);
        
        Assert.That(successOutcomeAmount3, Is.EqualTo(1));
    }
}