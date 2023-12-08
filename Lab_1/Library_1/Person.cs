using System.Net.Http.Headers;
using Library_1.Abstractions;

namespace Library_1;

public class Person
{
    public readonly Deck Deck = new();
    private readonly IStrategy _strategy;
    public Person(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public int SayCard()
    {
        return _strategy.Do(Deck);
    }

    public string GetCard(int index)
    {
        return Deck.Cards[index].Color;
    }
}