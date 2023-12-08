using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class EntireDeck : IEntireDeck
{ 
    public EntireDeck()
    {
        InitializeCards();
    }

    public ICollection<ACard> Cards { get; set; } = new List<ACard>();

    public void InitializeCards()
    {
        List<ACard> buff = Cards.ToList() ?? throw new ArgumentNullException("Cards.ToList()");
        for (var i = 0; i < 36; i++)
        {
            buff[i] = new Card("");
        }
    }
    public void Spread(Deck markDeck, Deck ilonDeck)
    {
        for (var i = 0; i < 18; i++)
        {
            markDeck.Cards[i]!.Color = Cards.ElementAt(i).Color;
        }

        for (var i = 18; i < 36; i++)
        {
            ilonDeck.Cards[i - 18]!.Color = Cards.ElementAt(i).Color;
        }
    }
}