using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace thegame.Controllers
{
    public class StartGameDTO
    {
        public int colorCount;
        public int h;
        public int w;
    }

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
        public IActionResult StartGame([FromBody] string patchDocument)
        {
            var jObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(patchDocument);
            //return BadRequest();
            game = new Game(int.Parse(jObj["h"]), int.Parse(jObj["w"]), int.Parse(jObj["colorCount"]));
            return Ok();
        }

        [HttpGet("{UserId}/getMap")]
        public IActionResult GetMap()
        {
            Console.Write(game.Map.Length);
            return Ok(game.Map);
        }

        [HttpPost("postColor/{UserId}/{color}")]
        public IActionResult PostColor()
        {
            return Ok(200);
        }
    }
}