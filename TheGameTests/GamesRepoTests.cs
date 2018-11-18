using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using thegame;
using thegame.Services;

namespace TheGameTests
{
    [TestFixture]
    public class GamesRepoTests
    {
        private GamesRepo gamesRepo;

        [SetUp]
        public void Setup()
        {
            gamesRepo = new GamesRepo();
            for (int i = 0; i < 15; i++)
            {
                var game = gamesRepo.NewGame(Guid.NewGuid());
                game.Score = i;
            }
        }

        [Test]
        public void GetTopSessions_IsCorrect()
        {
            var topGames = gamesRepo.GetTopSessions().ToArray();
            Assert.AreEqual(14, topGames[0].Score);
            Assert.AreEqual(13, topGames[1].Score);
            Assert.AreEqual(12, topGames[2].Score);
        }
    }
}
