using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;

namespace ClassLibrary1.Implementations;

public class SpecialDeckShuffler : IDeckShuffler
{
    public void Shuffle(IEntireDeck entireDeck)  // ShellDeck
    {
        for (var i = 0; i < 36; i++)
        {
            // Нарушение DIP
            var buff = ((IDeckShuffler)this).GetRandom();

            ((ShellDeck)entireDeck).Cards[i].Color = buff == 0 ? "red" : "black";
        }
    }
}