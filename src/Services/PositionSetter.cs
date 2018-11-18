using System;
using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class PositionHandler
    {
        public void SetPosition(GameLogic game, UserInputForMovesPost userInput)
        {
            if (!IsCorrectInput(userInput))
                return;
            if (userInput.KeyPressed != default(char))
            {
                switch ((int)userInput.KeyPressed)
                {
                    case 37:
                        game.Move(Direction.Left);
                        break;
                    case 39:
                        game.Move(Direction.Right);
                        break;
                    case 38:
                        game.Move(Direction.Up);
                        break;
                    case 40:
                        game.Move(Direction.Down);
                        break;
                }
            }
            else
            {
                game.Move(GetDirectionFromMouseClick(game, userInput));
            }
        }

        private Direction GetDirectionFromMouseClick(GameLogic game, UserInputForMovesPost userInput)
        {
            var direction = Direction.Up;
            var centerX = (double)game.Field.GetLength(0) / 2;
            var centerY = (double)game.Field.GetLength(1) / 2;
            var difX = userInput.ClickedPos.X - centerX;
            var difY = userInput.ClickedPos.Y - centerY;
            var difference = Math.Abs(difX) - Math.Abs(difY);
            Direction verticalDirection;
            Direction horizontalDirection;
            horizontalDirection = difX > 0 ? Direction.Right : Direction.Left;
            verticalDirection = difY > 0 ? Direction.Up : Direction.Down;
            return difference > 0 ? horizontalDirection : verticalDirection;
        }

        private bool IsCorrectInput(UserInputForMovesPost userInput)
        {
            return ((userInput.ClickedPos == null
                    && (userInput.KeyPressed >= 37 || userInput.KeyPressed <= 40))
                    || userInput.ClickedPos != null);
        }
    }
}
