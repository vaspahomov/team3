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
            var cells = (int[,])game.Field.Clone();
            positionSetter.SetPosition(game, userInput);
            CreaterGameDto.Ctreate(game.Field);
            var isEnd = IsFinish(cells, game.Field);
            GameDto dto = new GameDto(CreaterGameDto.Ctreate(game.Field),
                true, true, 4, 4, gameId, isEnd, game.Score);
            return new ObjectResult(dto);
        }

        private bool IsFinish(int[,] oldCells,int[,] newCells)
        {
            for (var i = 0; i < oldCells.GetLength(0); i++)
            {
                for (var j = 0; j < oldCells.GetLength(1); j++)
                {
                    if (oldCells[i, j] != newCells[i,j] || newCells[i, j]==0)
                        return false;

                }
            }
            return true;

        }
    }
}