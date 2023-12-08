using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class DeckShuffler : IDeckShuffler
{
    public void Shuffle(IEntireDeck entireDeck)
    {
        for (var i = 0; i < 36; i++)
        {
            var buff = ((IDeckShuffler)this).GetRandom(); 
            ((EntireDeck)entireDeck).Cards.Add(buff == 0 ? new Card("red") : new Card("black"));
        }
    }
}