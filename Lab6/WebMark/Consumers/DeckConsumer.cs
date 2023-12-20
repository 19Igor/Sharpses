using ClassLibrary1;
using ClassLibrary1.Abstractions;
using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Contracts;
using MassTransit;


namespace WebApplication1.Consumers;

public class DeckConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {
        List<SpecialCard>? deck = context.Message.Deck;
        IStrategy strategy = new Strategy1();
        MarkState.Cards = deck;
        var decision = strategy.Do(List2Deck(deck));
        context.Publish(new NumberMessage
        {
            Number = decision,
            Signature = "mark"
        });
        return Task.CompletedTask;
    }
    
    private Deck List2Deck(List<SpecialCard>? list)
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