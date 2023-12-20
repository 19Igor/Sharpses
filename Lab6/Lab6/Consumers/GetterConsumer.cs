using ClassLibrary1;
using Contracts;
using Lab4;
using MassTransit;

namespace Lab6.Consumers;

public class GetterConsumer : IConsumer<SenderCompleted>
{
    private readonly MyHttpClientHandler _httpclient;
    private readonly int _elonPort;
    private readonly int _markPort;

    public GetterConsumer(MyHttpClientHandler httpclient, int elonPort, int markPort)
    {
        _httpclient = httpclient;
        _elonPort = elonPort;
        _markPort = markPort;
    }

    public async Task Consume(ConsumeContext<SenderCompleted> context)
    {
        await DataManeger.Getter(_httpclient, _elonPort, _markPort);
        await context.Publish(new GetterCompleted());
    }
}