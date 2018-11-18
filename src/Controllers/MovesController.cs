using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private GamesRepo gamesRepo;
        private PositionHandler positionSetter;

        public MovesController(GamesRepo repo, PositionHandler positionSetter)
        {
            gamesRepo = repo;
            this.positionSetter = positionSetter;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = gamesRepo.GetGame(gameId);
            positionSetter.SetPosition(game, userInput);
            CreaterGameDto.Ctreate(game.Field);
            GameDto dto = new GameDto(CreaterGameDto.Ctreate(game.Field),
                true, true, 4, 4, gameId, false, 41);
            return new ObjectResult(dto);
        }
    }
}