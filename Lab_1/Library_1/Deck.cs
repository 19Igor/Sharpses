namespace Library_1;

public class Deck
{
    public readonly Card[] Cards = new Card[18];

    public Deck()
    {
        InitializeCards();
    }
    private void InitializeCards()
    {
        for (var i = 0; i < 18; i++)
        {
            Cards[i] = new Card("");
        }
    }
}