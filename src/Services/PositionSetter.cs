﻿using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class PositionHandler
    {
        public void SetPosition(GameLogic game, UserInputForMovesPost userInput)
        {
            if (IsCorrectInput(userInput))
                return;
            if (userInput.KeyPressed == default(char)) return;
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

        private bool IsCorrectInput(UserInputForMovesPost userInput)
        {
            return ((userInput.ClickedPos == null
                    && (userInput.KeyPressed < 37 || userInput.KeyPressed > 40))
                    || userInput.ClickedPos != null);
        }
    }
}
