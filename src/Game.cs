using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace thegame
{
    class Game : IGame
    {
        public int[,] Map { get; private set; }
        public int score { get; private set; }
        private readonly int ColorsCount;
        private readonly int Width;
        private readonly int Height;


        public Game(int h, int w, int colorsCount)
        {
            ColorsCount = colorsCount;
            Width = w;
            Height = h;

            Map = new int[h, w];
            MapGeneration();
        }

        private bool TryGetValue(int x, int y, out int value)
        {
            value = 0;
            try
            {
                value = Map[x, y];
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        
        public void DoStep(int color)
        {
            
            //Могут быть баги 
            //Вероятно, при Contains по хэшсету работает "неправильно"
            var visited = new HashSet<ValueTuple<int, int>>();
            
            
            
            var currentColor = Map[0, 0];
            var queue = new Queue<ValueTuple<int, int>>();
            queue.Enqueue((0 ,0));


            while (queue.Count != 0)
            {
                var currentPosition = queue.Dequeue();
                visited.Add(currentPosition);
                var currX = currentPosition.Item1;
                var currY = currentPosition.Item2;


                if (TryGetValue(currX + 1, currY, out var rightValue))
                {
                    if (rightValue == currentColor && !visited.Contains((currX + 1, currY)))
                        queue.Enqueue((currX + 1, currY));
                }
                if (TryGetValue(currX - 1, currY, out var leftValue))
                {
                    if (leftValue == currentColor && !visited.Contains((currX - 1, currY)))
                        queue.Enqueue((currX - 1, currY));
                }
                if (TryGetValue(currX, currY + 1, out var downValue))
                {
                    if (downValue == currentColor && !visited.Contains((currX, currY + 1)))
                        queue.Enqueue((currX, currY + 1));
                }
                if (TryGetValue(currX, currY - 1, out var upValue))
                {
                    if (upValue == currentColor && !visited.Contains((currX, currY - 1)))
                        queue.Enqueue((currX , currY - 1));
                }

                
            }

            score += visited.Count * 3;
            foreach (var cell in visited)
            {
                Map[cell.Item1, cell.Item2] = color;
            }
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
