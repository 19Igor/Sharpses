using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

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
        return Deck.Cards[index].Color;
    }
}