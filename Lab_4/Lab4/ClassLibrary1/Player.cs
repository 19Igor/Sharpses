using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;

namespace ClassLibrary1;

public class Player
{
    public readonly Deck Deck = new();
    private readonly IStrategy _strategy;
    public String Name { get; set; }
    public Player(String name, IStrategy strategy)
    {
        Name = name;
        _strategy = strategy;
    }

    public int SayCard()
    {
        return _strategy.Do(Deck);
    }

    public string GetCard(int index)
    {
        return Deck.Cards[index]!.Color;
    }
}