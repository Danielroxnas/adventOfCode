using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    static class Day11
    {
        public static void Part1()
        {
            //var input = "se,sw,se,sw,sw".Split(',').Select(x => x.Trim()).ToList();
            var input = File.ReadAllText("Day11/Day11.txt").Split(',').Select(x => x.Trim()).ToList();
            var cub = new Cub();
            input.ForEach(x => SetCube.SetCubeDirection(x, cub));
            var result = SetCube.Distance(cub);
        }

        public static void Part2()
        {
            var input = File.ReadAllText("Day11/Day11.txt").Split(',').Select(x => x.Trim()).ToList();
            var cub = new Cub();
            input.ForEach(x => { SetCube.SetCubeDirection(x, cub); SetCube.SetFurthest(cub); });
            var result = cub.Max;
        }

    }


    static class SetCube
    {
        public static void SetCubeDirection(string direction, Cub cub)
        {

            switch (direction)
            {
                case "n":
                    cub.SetDirection(0, 1, -1);
                    break;
                case "ne":
                    cub.SetDirection(1, 0, -1);
                    break;
                case "se":
                    cub.SetDirection(1, -1, 0);
                    break;
                case "s":
                    cub.SetDirection(0, -1, 1);
                    break;
                case "sw":
                    cub.SetDirection(-1, 0, 1);
                    break;
                case "nw":
                    cub.SetDirection(-1, 1, 0);
                    break;
                default:
                    break;
            }


        }
        public static int Distance(Cub a)
        {
            return (Math.Abs(a.X) + Math.Abs(a.Y) + Math.Abs(a.Z)) / 2;
        }


        public static void SetFurthest(Cub c)
        {
            var tmpList = new List<int>
            {
             Math.Abs(c.X),
             Math.Abs(c.Y),
             Math.Abs(c.Z)
            };

            if (c.Max < tmpList.Max())
            {
                c.Max = tmpList.Max();
            }
        }
    }


    class Cub
    {
        public int Max { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Cub()
        {
            X = 0;
            Y = 0;
            Z = 0;
            Max = 0;
        }

        public void SetDirection(int x, int y, int z)
        {
            X += x;
            Y += y;
            Z += z;
        }

    }
}
