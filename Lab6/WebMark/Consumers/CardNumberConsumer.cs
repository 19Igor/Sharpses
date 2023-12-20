using Contracts;
using MassTransit;

namespace WebApplication1.Consumers;

public class CardNumberConsumer : IConsumer<NumberMessage>
{
    public Task Consume(ConsumeContext<NumberMessage> context)
    {
        if (context.Message.Signature == "mark")
            return Task.CompletedTask;
        if (MarkState.Cards != null)
        {
            MarkState.Color = MarkState.Cards[context.Message.Number].Color;    
        }

        context.Publish(new PlayersAreReady());
        return Task.CompletedTask;
    }
}