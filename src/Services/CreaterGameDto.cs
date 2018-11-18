using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public static  class CreaterGameDto
    {
        public static CellDto[] Ctreate(int[,] numbers)
        {
            var cells = new List<CellDto>();
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    var content = numbers[i, j] == 0 ? "" : numbers[i, j].ToString();
                    var type = "tile-"+ content;
                    cells.Add(new CellDto($"{i}:{j}",
                        new Vec(i,j),
                        type,
                        content, 
                        10));
                }
            }

            return cells.ToArray();
        }
    }
}
