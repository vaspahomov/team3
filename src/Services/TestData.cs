using System;
using System.Drawing;
using thegame.Models;
using System.Linq;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 4;
            var height = 4;
            var map =  new CellDto[0];
            return new GameDto(map, true, true, width, height, Guid.NewGuid(), movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}