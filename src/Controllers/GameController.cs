using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace thegame.Controllers
{
    public class StartGameDTO
    {
        public int colorCount { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }

    [Route("api/game")]
    public class GameController : Controller
    {
        private static Game game { get; set; }

        [HttpGet("{UserId}/score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpPost("{UserId}/startGame")]
        public IActionResult StartGame([FromBody]
            JsonPatchDocument<StartGameDTO> patchDocument)
        {
            /*if (patchDocument is null)
                return BadRequest();
            var user = new StartGameDTO();
            patchDocument.ApplyTo(user, ModelState);*/
            game = new Game(5, 5, 5);
            return Ok();
        }

        [HttpGet("{UserId}/getMap")]
        public IActionResult GetMap()
        {
            //Console.Write(game.Map.Length);
            return Ok(game.Map);
        }

        [HttpPost("postColor/{UserId}/{color}")]
        public IActionResult PostColor()
        {
            return Ok(200);
        }
    }
}