using ClassLibrary1;
using ClassLibrary1.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebElon.Controllers;

// [Route("[controller]")]
// [ApiController]
// public class GameController : ControllerBase
// {
//    private readonly IStrategy _strategy;
//
//    public GameController(IStrategy strategy)
//    {
//       _strategy = strategy;
//    }
//
//    [HttpPost( "getchoice")]
//    public IActionResult GetChoice([FromBody] Deck cards)
//    {
//       var res = _strategy.Do(cards);
//       return Ok(res);
//    }
// }

[ApiController]
public class GameController : ControllerBase
{
    [Route("getcolor")]
    [HttpGet]
    public async Task<string?> GetColor()
    {
        Console.WriteLine("Collor from Elon's GetColor " + ElonState.Color);
        return await Task.FromResult(ElonState.Color);
    }
}
