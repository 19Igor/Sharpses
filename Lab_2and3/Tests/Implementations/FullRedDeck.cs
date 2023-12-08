using ClassLibrary1;
using ClassLibrary1.Abstractions;

namespace Tests.Implementations;

public class FullRedDeck : IDeckShuffler
{
    public void Shuffle(EntireDeck entireDeck)
    {
        for (int i = 0; i < 36; i++)
        {
            entireDeck.Cards[i].Color = "red";
        }
    }
}