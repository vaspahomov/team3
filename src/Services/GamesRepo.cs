using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo
    {
        private readonly Dictionary<Guid, GameLogic> gamesCollection;

        public GamesRepo()
        {
            gamesCollection = new Dictionary<Guid, GameLogic>();
        }

        public GameLogic NewGame(Guid Id)
        {
            var game = new GameLogic();
            gamesCollection.Add(Id, game);
            return game;
        }

        public GameLogic GetGame(Guid id)
        {
            GameLogic game;            
            return gamesCollection.TryGetValue(id, out game) ? game : NewGame(id);
        }
    }
}