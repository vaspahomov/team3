using System;
using System.Collections.Generic;
using System.Text;

namespace thegame
{
    class Game : IGame
    {
        public int[,] Map { get; private set; }
        private readonly int ColorsCount;
        private readonly int Width;
        private readonly int Height;

        public Game(int h, int w, int colorsCount = 5)
        {
            ColorsCount = colorsCount;
            Width = w;
            Height = h;
            Map = new int[h, w];
            MapGeneration();
        }

        public void DoStep(int color)
        {
            int currentColor = Map[0, 0];
            var queue = new Queue<ValueTuple<int, int>>();
            queue.Enqueue((0 ,0));
            throw new NotImplementedException();
        }

        public void MapGeneration()
        {
            var random = new Random();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Map[i, j] = random.Next(1, ColorsCount + 1);
                }
            }
        }
    }
}
