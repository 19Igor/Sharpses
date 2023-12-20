using Autofac;
using ClassLibrary1;
using ClassLibrary1.DB;
using Lab6.Consumers;
using MassTransit;

namespace Lab6.BusEntity;

public static class BusController 
{
    private const string RabbitMqUrl = "rabbitmq://localhost";
    private const string elonUrl = "rabbitmq://localhost/Elon_queue";
    private const string markUrl = "rabbitmq://localhost/Mark_queue";
    private const string LOGIN = "guest"; 
    private const string PASSWORD = "guest";
    private const int elonPort = 3001;
    private const int markPort = 3002;

    public static IBusControl LoadRabitMQ(MyHttpClientHandler httpHandler, DbInfo dbWorker)
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterInstance(new GetterConsumer(httpHandler, elonPort, markPort)).As<GetterConsumer>();
        containerBuilder.RegisterInstance(new SenderConsumer(dbWorker, elonUrl, markUrl)).As<SenderConsumer>();
        var container = containerBuilder.Build();
        
        // создание экземпляра шины
        var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
        {
            config.Host(new Uri(RabbitMqUrl), "/",h =>
            {
                h.Username(LOGIN);
                h.Password(PASSWORD);
            });
            config.ReceiveEndpoint("new_queue", pe =>
            {
                pe.Consumer<ReadyPlayersConsumer>();
                pe.Consumer(() => container.Resolve<GetterConsumer>());
                pe.Consumer(() => container.Resolve<SenderConsumer>());
            });
        });
        return busControl;
    }

    public static void StartBusControl(IBusControl busControl)
    {
        busControl.Start();
    }

    public static void StopBusControl(IBusControl busControl)
    {
        busControl.Stop();
    }
}