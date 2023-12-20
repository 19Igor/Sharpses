using System.Reflection;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;
using MassTransit;
using WebApplication1.Consumers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IStrategy, Strategy1>();
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    var entryAssembly = Assembly.GetEntryAssembly();
    x.AddConsumers(entryAssembly);
    x.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("Mark_queue", ep =>
        {
            ep.Consumer<CardNumberConsumer>();
            ep.Consumer<DeckConsumer>();
        });
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
