using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;

namespace ClassLibrary1.Implementations;

public class ShellDeck : IEntireDeck
{
    public List<ACard> Cards;

    public ShellDeck()
    {
        Cards = new List<ACard>();
        InitializeCards();
    }

    public void InitializeCards()
    {
        for (var i = 0; i < 36; i++)
        {
            Cards.Add(new CardForExperiment(" "));
        }
    }

    public void Spread(Deck markDeck, Deck ilonDeck)
    {
        for (var i = 0; i < 18; i++)
        {
            markDeck.Cards[i]!.Color = Cards[i].Color;
        }

        for (var i = 18; i < 36; i++)
        {
            ilonDeck.Cards[i - 18]!.Color = Cards[i].Color;
        }
    }
}