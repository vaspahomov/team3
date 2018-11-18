using System;
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
            return new ObjectResult(game);
        }

        
    }
}