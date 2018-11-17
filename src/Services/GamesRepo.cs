using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo
    {
        private readonly Dictionary<Guid, GameDto> gamesCollection;

        public GamesRepo()
        {
            gamesCollection = new Dictionary<Guid, GameDto>();
        }

        public GameDto NewGame()
        {
            var game = TestData.AGameDto(new Vec(3, 3));
            gamesCollection.Add(game.Id, game);
            return game;
        }

        public GameDto GetGame(Guid id)
        {
            GameDto game;            
            return gamesCollection.TryGetValue(id, out game) ? game : NewGame();
        }
    }
}