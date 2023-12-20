using System.Runtime.InteropServices.JavaScript;
using Contracts;
using MassTransit;

namespace WebElon.Consumers;

public class CardNumberConsumer : IConsumer<NumberMessage>
{
    public Task Consume(ConsumeContext<NumberMessage> context)
    {
        Console.WriteLine("Hello from Elon's NumberConsumer.");
        if (context.Message.Signature == "elon")
        {
            return Task.CompletedTask;
        }
        if (ElonState.Cards != null)
        {
            ElonState.Color = ElonState.Cards[context.Message.Number].Color;
            // ElonStates.Color = ElonStates.Cards.Cards[context.Message.Number]!.Color;
        }

        context.Publish(new PlayersAreReady());
        return Task.CompletedTask;
    }
}