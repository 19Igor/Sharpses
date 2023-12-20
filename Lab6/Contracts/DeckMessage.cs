using ClassLibrary1;

namespace Contracts;

public record DeckMessage()
{
    public List<SpecialCard>? Deck { get; set; }
}