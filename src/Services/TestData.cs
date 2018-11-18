﻿using System;
using System.Drawing;
using thegame.Models;
using System.Linq;

namespace thegame.Services
{
    public class TestData
    {


        public static GameDto AGameDto(Vec movingObjectPosition)
        {

            var width = 12;
            var height = 12;
            MapCreator mapCreator = new MapCreator();
            var map = mapCreator.CreateMap(width, height);



           




            return new GameDto(map, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }

        


    }
}