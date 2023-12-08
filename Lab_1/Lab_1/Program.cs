using Library_1;
using Library_1.Abstractions;
using Library_1.Implementations;

namespace Lab_1;

class Program
{
    private static void Main()
    {
        // hosted services посмотреть 
        // const double count = 1000000;
        const double count = 100000;
        var amount = 0;
        IStrategy strategy = new Strategy1();
        Person mark = new(strategy);
        Person ilon = new(strategy);
        EntireDeck entireDeck = new();
        
        for (var i = 0; i < count; i++)
        {
            entireDeck.Shuffle();
            entireDeck.Spread(mark.Deck, ilon.Deck);
            amount += ilon.GetCard(mark.SayCard()) == mark.GetCard(ilon.SayCard()) ? 1 : 0;
        }
        Console.WriteLine("Amount of same cards: " + amount);
        Console.WriteLine("Result: " + amount / count * 100 + "%");
    }
}
