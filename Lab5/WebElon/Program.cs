using ClassLibrary1.Abstractions;
using ClassLibrary1.Implementations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IStrategy, Strategy1>();
// builder.Services.AddHttpClient();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();