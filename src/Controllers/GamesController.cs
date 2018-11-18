using System;
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

            var gameId = Guid.NewGuid();
            var game = gamesRepo.NewGame(gameId);
            GameDto dto = new GameDto(CreaterGameDto.Ctreate(game.Field),
                true, true, 4, 4, gameId, false, 0);
            CreaterGameDto.Ctreate(game.Field);
            return new ObjectResult(dto);
        }
    }
}
