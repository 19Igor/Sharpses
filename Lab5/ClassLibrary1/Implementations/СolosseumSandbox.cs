using System.Text;
using ClassLibrary1.Abstractions;
using Newtonsoft.Json;

namespace ClassLibrary1.Implementations;

public class СolosseumSandbox : IСolosseumSandbox
{
    private readonly IDeckShuffler _deckShuffler;
    private readonly Player _mark;
    private readonly Player _elon;
    public СolosseumSandbox(IDeckShuffler deckShuffler, IEnumerable<Player> players)
    {
        _deckShuffler = deckShuffler;
        var enumerable = players.ToList();
        _elon = enumerable.ElementAt(0);
        _mark = enumerable.ElementAt(1);
    }
    
    public Task<int> Experiment()
    {
        var entireDeck = new EntireDeck();
        _deckShuffler.Shuffle(entireDeck);
        entireDeck.Spread(_mark.Deck, _elon.Deck);
        return Task.FromResult(_elon.GetCard(_mark.SayCard()) == _mark.GetCard(_elon.SayCard()) ? 1 : 0);
    }

    // not used
    public void SetEntireDeck(ShellDeck entireDeck)
    {
        throw new NotImplementedException();
    }
}
