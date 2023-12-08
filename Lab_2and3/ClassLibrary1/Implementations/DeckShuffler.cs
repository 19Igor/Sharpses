using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class DeckShuffler : IDeckShuffler
{
    public void Shuffle(EntireDeck entireDeck)
    {
        for (int i = 0; i < 36; i++)
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