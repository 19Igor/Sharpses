using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Tests.Implementations;

namespace Tests;

public class Point1
{
    [SetUp]
    public void Setup()
    {
    }

    // Nunit 
    [Test]
    public void Deck_after_shuffle_has_18red_and_18black_cards()
    {
        IDeckShuffler deckShuffler = new TestShuffler();
        EntireDeck entireDeck = new EntireDeck();
        deckShuffler.Shuffle(entireDeck);
        int redNumber = 0;
        int blackNumber = 0;

        for (int i = 0; i < 36; i++)
        {
            if (entireDeck.Cards[i].Color.Equals("red"))
                redNumber++;
            else
                blackNumber++;
        }
        Assert.That(redNumber, Is.EqualTo(blackNumber));
    }   
}