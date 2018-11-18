using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public class MapCreator
    {
        private readonly HashSet<Point> createdPoints = new HashSet<Point>();
        private readonly string Width;
        private readonly string Height;
        private readonly string _map;

        public CellDto[] CreateMap(int width, int height)
        {
            CellDto  unit = CreateObject(new Point(0, 0), "unit");
            CellDto  controlUnit = CreateObject(new Point(3, 0), "color4");
            CellDto unit1 = CreateObject(new Point(0, 0), "unit");
            CellDto[] easyMap = new CellDto[3]{ unit, controlUnit, unit1 };
          
            return easyMap;
        }



        private CellDto CreateObject(Point point , string typeObject)
        {
            if (IsNewPoint(point))
            {
                createdPoints.Add(point);
                return new CellDto($"{0 + point.X},{point.Y}", new Vec(0 + point.X, point.Y), typeObject, "2", 10);
            }
            return new CellDto($"{-1},{-1}", new Vec(-1, -1), "color0", "", 0);
            //CellDto[] bricks1 = GetBricks(new Point(0, 0), 10, true);
            //CellDto[] bricks2 = GetBricks(new Point(0, 10), 10, true);
            //CellDto[] bricks3 = GetBricks(new Point(0, 1), 8, false);
            //// CellDto[] bricks4 = GetBricks(new Point(0, 1), 10, false);

            //var bricks = bricks1.Concat(bricks2).Concat(bricks3).ToArray();
            //var cells1 = Enumerable.Range(0, 10)
            //    .SelectMany(x => Enumerable.Range(0, 10).Select(y => new CellDto($"{x},{y}", new Vec(x, y), "bricks", "", 0)))
            //    .Concat(new[] { new CellDto("5", new Vec(2, 2), "package", "", 10), new CellDto("unicorn", movingObjectPosition, "unicorn", "", 10) })
            //    .ToArray();

            //var cells2 = Enumerable.Range(0, 10)
            //    .SelectMany(x => Enumerable.Range(10, 10).Select(y => new CellDto($"{x},{y}", new Vec(x, y), "bricks", "", 0)))
            //    .Concat(new[] { new CellDto("5", new Vec(2, 2), "package", "", 10), new CellDto("unicorn", movingObjectPosition, "unicorn", "", 10) })
            //    .ToArray();

            //var cells = cells1.Concat(cells2).ToArray();

            //var testCells = new[]
            //{
            //    new CellDto("1", new Vec(2, 4), "bricks", "", 0),
            //    new CellDto("1", new Vec(2, 4), "bricks", "", 0),
            //    new CellDto("2", new Vec(5, 4), "bricks", "", 0),
            //    new CellDto("3", new Vec(3, 1), "bricks2", "", 20),
            //    new CellDto("4", new Vec(1, 0), "bricks2", "", 20),
            //    new CellDto("5", new Vec(2, 2), "package", "", 10),
            //    new CellDto("unicorn", movingObjectPosition, "unicorn", "", 10),
            //};
            //bricks = bricks.Concat(new[]
            //    {
            //        new CellDto("5", new Vec(5,9), "package", "", 10),
            //        new CellDto("unicorn", movingObjectPosition, "unicorn", "", 10)
            //    })
            //    .ToArray();

            throw new NotImplementedException();
        }

        private bool IsNewPoint(Point point)
        {
            return !createdPoints.Contains(point);
          
        }

        private static CellDto[] GetBricks(Point pointStart, int count, bool isVertically)
        {
            if (isVertically == true)
                return Enumerable.Range(0, count)
                    .Select(x => new CellDto($"{x + pointStart.X},{pointStart.Y}", new Vec(x + pointStart.X, pointStart.Y), "bricks", "", 0))
                    .ToArray();

            return Enumerable.Range(0, count)
                .Select(y => new CellDto($"{pointStart.X},{pointStart.Y + y}", new Vec(pointStart.X, pointStart.Y + y), "bricks", "", 0))
                .ToArray();
        }


    }
}
