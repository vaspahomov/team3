using System;
using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("getField")]
        public IActionResult GetField()
        {
            throw new NotImplementedException();
        }

        [HttpPost("postColor/{color}")]
        public IActionResult PostColor()
        {
            return Ok(200);
        }
    }

}
