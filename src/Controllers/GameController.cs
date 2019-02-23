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
        private static Game game = new Game(5, 5, 5);

        [HttpGet("{UserId}/score")]
        public IActionResult Score([FromRoute] Guid Id)
        {
            return Ok(50);
        }

        [HttpPost("{UserId}/startGame")]
        public IActionResult StartGame([FromRoute] Guid Id, [FromBody]
            JsonPatchDocument<StartGameDTO> patchDocument)
        {
            /*if (patchDocument is null)
                return BadRequest();
            var user = new StartGameDTO();
            patchDocument.ApplyTo(user, ModelState);*/
            
            return Ok();
        }

        [HttpGet("{UserId}/getMap")]
        public IActionResult GetMap([FromRoute] Guid Id)
        {
            //Console.Write(game.Map.Length);
            return Ok(game.Map);
        }

        [HttpPost("{UserId}/postColor/{color}")]
        public IActionResult PostColor([FromRoute] Guid Id, [FromRoute] int color)
        {
            game.DoStep(color);
            return Ok(200);
        }
    }
}