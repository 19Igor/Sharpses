using ClassLibrary1.Implementations;

namespace ClassLibrary1.Abstractions;

public interface IСolosseumSandbox
{
    public Task<int> Experiment();
    void SetEntireDeck(ShellDeck entireDeck);
}