using System.Net.Http.Json;
using System.Text;
using ClassLibrary1.Implementations;
using Newtonsoft.Json;

namespace ClassLibrary1;

public class MyHttpClientHandler
{
    public MyHttpClientHandler()
    {
    }

    public async Task<int> SendDeck(Deck deck, int port)
    {
        int res = await SendDeckAsync(deck, port); 
        return res;
    }

    private static async Task<int> SendDeckAsync(Deck deck, int port)
    {
        using var client = new HttpClient();
        string json = JsonConvert.SerializeObject(deck);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        
        int responseBody = 0;
        try
        {
            using var response = await client.PostAsync($"http://localhost:{port}/game/getchoice", content);
            response.EnsureSuccessStatusCode();
            responseBody = Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine(e);
        }
        return responseBody;
    }
    
} 