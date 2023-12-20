using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using Contracts;
using MassTransit;

namespace WebElon.Consumers;

public class DeckConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {
        Console.WriteLine("Hello from DeckConsumer");
        var deck = context.Message.Deck; // Deck
        IStrategy strategy = new Strategy1();
        ElonState.Cards = deck; 
        Console.WriteLine("Hello from WebElon.DeckConsumer");
        var decision = strategy.Do(SpecialCard2Deck(deck)); // Deck
        context.Publish(new NumberMessage
        {
            Number = decision,
            Signature = "elon"
        });
        return Task.CompletedTask;
    }

    private Deck SpecialCard2Deck(List<SpecialCard>? list)
    {
        int index = 0; 
        Deck buff = new Deck();
        foreach (var variable in list!)
        {
            buff.Cards[index]!.Color = variable.Color;
            index++;
        }

        return buff;
    }
}