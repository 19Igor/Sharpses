using System;

namespace ClassLibrary1.Abstractions;

public interface IDeckShuffler
{
    public void Shuffle(IEntireDeck entireDeck);

    public int GetRandom()
    {
        // 245
        Random rnd = new Random();
        int value = rnd.Next(0, 2);
        return value;
    }
}