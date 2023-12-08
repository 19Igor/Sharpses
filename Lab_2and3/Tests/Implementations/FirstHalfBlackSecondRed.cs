using ClassLibrary1;
using ClassLibrary1.Abstractions;

namespace Tests.Implementations;

public class FirstHalfBlackSecondRed : IDeckShuffler
{
    public void Shuffle(EntireDeck entireDeck)
    {
        for (int i = 0; i < 18; i++)
        {
            entireDeck.Cards[i].Color = "black";
            entireDeck.Cards[i + 18].Color = "red";
        }
    }
}