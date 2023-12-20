using Contracts;
using MassTransit;

namespace Lab4.BusEntity;

public class EndPointLoader
{
    public static async Task<(ISendEndpoint, ISendEndpoint)> PlayersEndPointLoader(ConsumeContext context, string url1, string url2)
    {
        return (await context.GetSendEndpoint(new Uri(url1)), await context.GetSendEndpoint(new Uri(url2)));
    }
}