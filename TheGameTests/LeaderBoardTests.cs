using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using thegame.Models;

namespace TheGameTests
{
    [TestFixture]
    public class LeaderBoardTests
    {
        private LeaderBoard leadBoard;
        private string leadBoardFilename = "tests_leaderboard.txt";
        private int count = 0;

        [SetUp]
        public void Setup()
        {
            count = 3;
            leadBoard = new LeaderBoard();
            leadBoard.ClearAllResults(leadBoardFilename);
            for (var i = 0; i < count; i++)
            {
                var rcd = new LeaderBoardRecord { Score = i, Id = Guid.NewGuid() };
                leadBoard.SaveNewResult(rcd, leadBoardFilename);
            }
        }

        [Test]
        public void AddLeaderBoardRecords_OrderIsCorrect()
        {
            var lead = leadBoard.GetTopSessions(leadBoardFilename);
            Assert.AreEqual(count - 1, lead[0].Score);            
        }
    }
}
