namespace Library_1.Abstractions;

public interface IStrategy
{
    // Interfaces can contain properties and methods, but not fields.       
    int Do(Deck deck);
}
