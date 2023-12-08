using ClassLibrary1.DB;
using ClassLibrary1.Implementations;

namespace ClassLibrary1.Abstractions;

public interface IEntireDeck
{
    protected void InitializeCards();
    public void Spread(Deck markDeck, Deck ilonDeck);
}