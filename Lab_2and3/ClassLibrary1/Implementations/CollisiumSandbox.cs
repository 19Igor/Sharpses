using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class CollisiumSandbox : ICollisiumSandbox
{
    public override int Experiment(Player mark, Player elon, IDeckShuffler deckShuffler)
    {
        EntireDeck entireDeck = new();

        deckShuffler.Shuffle(entireDeck);
        entireDeck.Spread(mark.Deck, elon.Deck);
        return elon.GetCard(mark.SayCard()) == mark.GetCard(elon.SayCard()) ? 1 : 0;
    }
}
