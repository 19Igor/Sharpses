using ClassLibrary1;
using ClassLibrary1.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IStrategy _strategy;

    public GameController(IStrategy strategy)
    {
        _strategy = strategy;
    }
    
    [HttpPost("getchoice")]
    public IActionResult GetChoice([FromBody] Deck cards) // Deck из 18 карт
    {
        var res = _strategy.Do(cards);
        return Ok(res);
    }
}