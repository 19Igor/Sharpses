using System.Diagnostics.CodeAnalysis;

namespace ClassLibrary1;
public class Deck
{
    public readonly Card[] Cards = new Card[18];

    public Deck()
    {
        InitializeCards();
    }
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: ClassLibrary1.Card; size: 416MB")]
    private void InitializeCards()
    {
        for (var i = 0; i < 18; i++)
        {
            Cards[i] = new Card("");
        }
    }
}