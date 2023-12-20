using Contracts;
using Lab4;
using MassTransit;

namespace Lab6.Consumers;

public class ReadyPlayersConsumer : IConsumer<PlayersAreReady>
{
    public Task Consume(ConsumeContext<PlayersAreReady> context)
    {
        lock (ReadyPlayerState.LockObject)
        {
            ReadyPlayerState.CountReady += 1;
            if (ReadyPlayerState.CountReady != 2) return Task.CompletedTask;
            context.Publish(new SenderCompleted());
            ReadyPlayerState.CountReady = 0;
        }

        return Task.CompletedTask;
    }
}