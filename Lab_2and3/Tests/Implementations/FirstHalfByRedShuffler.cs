using ClassLibrary1;
using ClassLibrary1.Abstractions;

namespace Tests.Implementations;

public class FirstHalfByRedShuffler : IDeckShuffler
{
    public void Shuffle(EntireDeck entireDeck)
    {
        for (int i = 0; i < 18; i++)
        {
            entireDeck.Cards[i].Color = "red";
        }

        for (int i = 18; i < 36; i++)
        {
            var buff = GetRandom();
            entireDeck.Cards[i].Color = (buff == 0) ? "red" : "black";
        }
        
    }
    
    private static int GetRandom()  
    {
        // 245
        Random rnd = new Random();
        int value = rnd.Next(0, 2);
        return value;
    }
}