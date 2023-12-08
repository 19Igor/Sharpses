namespace ClassLibrary1;

public class EntireDeck
{
    public Card[] Cards = new Card[36];

    public EntireDeck()
    {
        InitializeCards();
    }
    private void InitializeCards()
    {
        for (int i = 0; i < 36; i++)
        {
            Cards[i] = new Card("");
        }
    }

    public void Shuffle()
    {
        for (var i = 0; i < 36; i++)
        {
            var buff1 = GetRandom();
            Cards[i].Color = (buff1 == 0) ? "red" : "black";
        }
    }
    
    private static int GetRandom()  
    {
        // 245
        Random rnd = new Random();
        int value = rnd.Next(0, 2);
        return value;
    }

    public void Spread(Deck markDeck, Deck ilonDeck)
    {
        for (int i = 0; i < 18; i++)
        {
            markDeck.Cards[i] = Cards[i];
        }

        for (int i = 18; i < 36; i++)
        {
            ilonDeck.Cards[i - 18] = Cards[i];
        }
    }

    
}