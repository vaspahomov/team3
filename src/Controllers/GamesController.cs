using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {        
        private GamesRepo gamesRepo;

        public GamesController(GamesRepo repo)
        {
            gamesRepo = repo;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return new ObjectResult(gamesRepo.NewGame());
            //return new ObjectResult(TestData.AGameDto(new Vec(1, 1)));
        }
    }
}
