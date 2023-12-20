using ClassLibrary1;
using ClassLibrary1.DB;
using Contracts;
using MassTransit;
using Newtonsoft.Json;

namespace Lab4;

public class DataManeger
{
    public static readonly Semaphore Semaphore = new(0, 1);
    public static int TotalExperiments { get; set; } = 100;
    private static int Count { get; set; }
    private static int TotalSuccesses { get; set; }


    public static async Task Sender(DbInfo dbWorker, ISendEndpoint elonEndPoint, ISendEndpoint markEndPoint)
    {
        if (TotalExperiments == Count)
        {
            Finish();
            return;
        }
        Console.WriteLine("Hello from DataControl.Sender!");
        
        var (elonCards, markCards) =  DataBaseWorker.ReadDataBase(dbWorker.DB, dbWorker.Index);  // ------------------------------------------
        
        if (elonCards != null && markCards != null)
        {
            
            await Task.WhenAll(elonEndPoint.Send(new DeckMessage { Deck = elonCards }),    
                               markEndPoint.Send(new DeckMessage { Deck = markCards }));  
        }
        else
        {
            TotalExperiments = Count;
            Finish();
            Semaphore.Release();
        }
        dbWorker.Index++;
    }

    public static async Task Getter(MyHttpClientHandler httpClientHandler, int elonPort, int markPort)
    {
        if (TotalExperiments == Count)
        {
            Finish();
            return;
        }
        
        Console.WriteLine("Hello from DataControl.Getter!");
        var res = await Task.WhenAll(
            httpClientHandler.GetColor(elonPort), httpClientHandler.GetColor(markPort)
        );

        if (res[0] == res[1])
        {
            TotalSuccesses++;
        }
        Count++;
    }

    private static void Finish()
    {
        Semaphore.Release();
        double res = (double)TotalSuccesses / TotalExperiments * 100;
        Console.WriteLine("Amount of same cards: " + TotalSuccesses);
        Console.WriteLine("Result: " + res + "%");
    }
}