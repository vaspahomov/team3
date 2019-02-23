using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private Game game;

        [HttpGet("{UserId}/score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpPost("{UserId}/startGame")]
        public IActionResult StartGame([FromBody] int h, [FromBody] int w, [FromBody] int colorCount)
        {
            //TODO Не пересоздавать игру
            game = new Game(h, w, colorCount);
            return Ok(100);
        }
        [HttpGet("{UserId}/getMap")]
        public IActionResult GetMap()
        {
            return Ok(game.Map);
        }

        [HttpPost("postColor/{UserId}/{color}")]
        public IActionResult PostColor()
        {

            return Ok(200);
        }
    }

}
