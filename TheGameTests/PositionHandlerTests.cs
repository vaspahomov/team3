using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using thegame;
using thegame.Models;
using thegame.Services;

namespace Tests
{
    public class PositionHandlerTests
    {
        GameLogic game;
        PositionHandler positionSetter;
        private GamesRepo gamesRepo;
        private UserInputForMovesPost userInput;
        private Guid gameId;

        [SetUp]
        public void Setup()
        {
            positionSetter = new PositionHandler();
            gameId = Guid.NewGuid();
            gamesRepo = new GamesRepo();
            game = gamesRepo.NewGame(gameId);
        }

        [TestCase(Direction.Up, 1, 0)]
        [TestCase(Direction.Left, 0, 1)]
        [TestCase(Direction.Right, 3, 1)]
        [TestCase(Direction.Right, 3, 2)]
        [TestCase(Direction.Down, 2, 3)]
        public void GetDirectionFromMouse_Field4x4_IsCorrect(Direction expected, int X, int Y)
        {
            userInput = new UserInputForMovesPost('\0', new Vec(X, Y));                        
            Assert.AreEqual(expected, positionSetter.GetDirectionFromMouseClick(game, userInput));
        }
    }
}