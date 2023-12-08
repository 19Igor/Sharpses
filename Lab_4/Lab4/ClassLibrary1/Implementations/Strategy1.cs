using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class Strategy1 : IStrategy
{
    private const string EXPECTED_COLOR = "red";
    private const int LAST_INDEX = 17;
    private Deck PlayerDeck { set; get; } = null!;

    public int Do(Deck deck)
    {
        PlayerDeck = deck;
        return GetCardNumber(0);
    }

    private int GetCardNumber(int index)
    {
        if (PlayerDeck.Cards[index]!.Color == EXPECTED_COLOR || index == LAST_INDEX)
            return index;
        return GetCardNumber(index + 1);
    }
}
