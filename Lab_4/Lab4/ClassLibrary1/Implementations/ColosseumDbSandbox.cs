using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;

namespace ClassLibrary1.Implementations;

public class ColosseumDbSandbox : IСolosseumSandbox
{
    private readonly Player _mark;
    private readonly Player _elon;
    private IEntireDeck _entireDeck;
    
    public ColosseumDbSandbox(IEnumerable<Player> players)
    {
        var enumerable = players.ToList();
        _elon = enumerable.ElementAt(0);
        _mark = enumerable.ElementAt(1);
    }
    
    public int Experiment()
    {
        _entireDeck.Spread(_mark.Deck, _elon.Deck);
        return _elon.GetCard(_mark.SayCard()) == _mark.GetCard(_elon.SayCard()) ? 1 : 0;
    }

    public void SetEntireDeck(ShellDeck entireDeck)
    {
        _entireDeck = entireDeck;
    }
}

















