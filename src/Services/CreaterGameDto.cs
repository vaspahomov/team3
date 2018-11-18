using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public class CreaterGameDto
    {
        public CellDto[] Ctreate(int[,] numbers)
        {
            var cells = new List<CellDto>();
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    var content = "collor"+Math.Log(numbers[i, j]);
                    cells.Add(new CellDto((i*j).ToString(),new Vec(i,j),content,numbers[i,j].ToString(), 0));
                }
            }

            return cells.ToArray();
        }
    }
}
