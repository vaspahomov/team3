using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace thegame.Controllers
{
    public class StartGameDTO
    {
        public int h;
        public int w;
        public int colorCount;
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
        public IActionResult StartGame([FromBody] JsonPatchDocument<StartGameDTO> patchDocument)
        {
            //TODO Не пересоздавать игру
            if (patchDocument is null)
                return BadRequest();
            var startGameDTO = new StartGameDTO();
            patchDocument.ApplyTo(startGameDTO, ModelState);
            game = new Game(startGameDTO.h, startGameDTO.w, startGameDTO.colorCount);
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
