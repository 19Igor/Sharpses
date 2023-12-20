using ClassLibrary1.DB;
using Contracts;
using Lab4;
using Lab4.BusEntity;
using MassTransit;

namespace Lab6.Consumers;

public class SenderConsumer : IConsumer<GetterCompleted>
{
    private readonly DbInfo _dbWorker;
    private readonly string _url1;
    private readonly string _url2;
    public SenderConsumer(DbInfo dbWorker, string elonUrl, string markUrl)
    {
        _dbWorker = dbWorker;
        _url1 = elonUrl;
        _url2 = markUrl;
    }

    public async Task Consume(ConsumeContext<GetterCompleted> context)
    {
        var (elonEndPoint, markEndPoint) = EndPointLoader.PlayersEndPointLoader(context, _url1, _url2).Result;
        await DataManeger.Sender(_dbWorker, elonEndPoint, markEndPoint);
    }
}