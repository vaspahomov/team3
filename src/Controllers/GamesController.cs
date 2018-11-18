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
        public IActionResult Index([FromBody]FieldSizePost fieldSize)
        {
            var gameId = Guid.NewGuid();
            var game = gamesRepo.NewGame(gameId, (fieldSize.Rows, fieldSize.Columns));
            GameDto dto = new GameDto(CreaterGameDto.Ctreate(game.Field),
                true, true, fieldSize.Rows, fieldSize.Columns, gameId, false, 0);
            CreaterGameDto.Ctreate(game.Field);
            return new ObjectResult(dto);
        }
    }
}
