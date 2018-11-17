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

        public MovesController(GamesRepo repo)
        {
            gamesRepo = repo;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = gamesRepo.GetGame(gameId);
            SetNewPosition(game, userInput);
            return new ObjectResult(game);
        }

        private void SetNewPosition(GameDto game, UserInputForMovesPost userInput)
        {
            if (IsCorrectInput(userInput))
                return;
            var newPos = game.Cells.First(c => c.Type == "color4").Pos;
            if (userInput.KeyPressed != default(char))
            {
                switch ((int)userInput.KeyPressed)
                {
                    case 37:
                        newPos.X--;
                        break;
                    case 39:
                        newPos.X++;
                        break;
                    case 38:
                        newPos.Y--;
                        break;
                    case 40:
                        newPos.Y++;
                        break;
                }
            }
            else
            {
                newPos = userInput.ClickedPos;
            }
            game.MoveTo(newPos);            
        }

        private bool IsCorrectInput(UserInputForMovesPost userInput)
        {
            return (userInput.ClickedPos == null
                     && (userInput.KeyPressed < 37 || userInput.KeyPressed > 40));
        }
    }
}