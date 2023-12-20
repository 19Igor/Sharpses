using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Implementations;

public class ColosseumDbSandbox : IСolosseumSandbox
{
    private readonly Player _mark;
    private readonly Player _elon;
    private IEntireDeck _entireDeck;
    private readonly MyHttpClientHandler _myHttpClientHandler;
    private const int MarkPort = 5000;
    private const int ElonPort = 4321;
    
    public ColosseumDbSandbox(IEnumerable<Player> players, MyHttpClientHandler myHttpClientHandler)
    {
        var enumerable = players.ToList();
        _elon = enumerable.ElementAt(0);
        _mark = enumerable.ElementAt(1);
        _myHttpClientHandler = myHttpClientHandler;
    }
    
    public async Task<int> Experiment()
    {
        _entireDeck.Spread(_mark.Deck, _elon.Deck);

        if (_mark.Deck == null || _elon.Deck == null)
        {
            return -1;
        }
        
        var markNumber = await _myHttpClientHandler.SendDeck(_mark.Deck, MarkPort);
        var elonNumber = await _myHttpClientHandler.SendDeck(_elon.Deck, ElonPort);
        
        int buff = _elon.Deck.Cards[markNumber]?.Color == _mark.Deck.Cards[elonNumber]?.Color ? 1 : 0;
        return buff;
    }

    public void SetEntireDeck(ShellDeck entireDeck)
    {
        _entireDeck = entireDeck;
    }
}
