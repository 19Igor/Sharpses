using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Moq;

namespace Tests;

public class Point3
{
    [SetUp]
    public void Setup()
    {
        // do something
    }
    
    [Test]
    public void MoqCheck()
    {
        ICollisiumSandbox coliseumSandbox = new CollisiumSandbox();
        // IDeckShuffler deckShuffler3 = new FullRedDeck();
        var mockService = new Mock<IDeckShuffler>();
        var deckShuffler = mockService.Object;
        var mark = new Player("Mark", new Strategy1());
        var elon = new Player("Elon", new Strategy1());

        coliseumSandbox.Experiment(mark, elon, deckShuffler);

        mockService.Verify(mock => mock.Shuffle(It.IsAny<EntireDeck>()), Times.Once);
    }
}