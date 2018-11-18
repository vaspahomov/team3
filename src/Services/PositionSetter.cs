using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class PositionSetter
    {
        public void SetPosition(GameDto game, UserInputForMovesPost userInput)
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
