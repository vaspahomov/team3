using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;

namespace thegame.Controllers
{
    [Route("api/stats")]
    public class StatsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var leaderBoard = new LeaderBoard();
            var results = leaderBoard.GetTopSessions();
            return new ObjectResult(results);
        }
    }
}
