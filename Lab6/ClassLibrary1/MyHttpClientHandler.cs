using System.Text;
using Newtonsoft.Json;

namespace ClassLibrary1;

public sealed class MyHttpClientHandler : IDisposable
{
    private readonly HttpClient _httpClient;

    public MyHttpClientHandler(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<string> GetColor(int port)
    {
        var response = await _httpClient.GetAsync($"http://localhost:{port}/getcolor");
        response.EnsureSuccessStatusCode();
        var colorString = await response.Content.ReadAsStringAsync();
        
        
        return colorString;
    }

    // public async Task<int> SendDeck(Deck deck, int port)
    // {
    //     int res = await SendDeckAsync(deck, port); 
    //     return res;
    // }
    //
    // private async Task<int> SendDeckAsync(Deck deck, int port)
    // {
    //     string json = JsonConvert.SerializeObject(deck);
    //     HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
    //     
    //     int responseBody = 0;
    //     try
    //     {
    //         using var response = await _httpClient.PostAsync($"http://localhost:{port}/game/getchoice", content);
    //         response.EnsureSuccessStatusCode();
    //         responseBody = Convert.ToInt32(await response.Content.ReadAsStringAsync());
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("------------------------------------------------------------------------------");
    //         Console.WriteLine(e);
    //     }
    //     return responseBody;
    // }

    public void Dispose() => _httpClient.Dispose();
} 