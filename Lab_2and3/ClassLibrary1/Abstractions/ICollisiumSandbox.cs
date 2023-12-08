using ClassLibrary1.Implementations;

namespace ClassLibrary1.Abstractions;

public abstract class ICollisiumSandbox
{
    public abstract int Experiment(Player mark, Player elon, IDeckShuffler deckShuffler);
}