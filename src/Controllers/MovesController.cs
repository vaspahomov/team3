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
            var isEnd = true;
            for (var i = 0; i < game.Field.GetLength(0); i++)
            {
                for (var j = 0; j < game.Field.GetLength(1); j++)
                {
                    if (game.Field[i, j] == 0)
                        isEnd = false;

                }
            }
            GameDto dto = new GameDto(CreaterGameDto.Ctreate(game.Field),
                true, true, 4, 4, gameId, isEnd, game.Score);
            return new ObjectResult(dto);
        }
    }
}