using System.Diagnostics.CodeAnalysis;
using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;
public class Deck
{
    public readonly Card?[] Cards = new Card[18];

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