using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class Day5
    {
        private static int newI = 0;
        private static int jumps = 0;
        private static int oldie = 0;

        public static void Part1()
        {

            var list = File.ReadAllLines("Day5/Day5.txt").Select(x => int.Parse(x)).ToArray();
            while (newI < list.Length)
            {
                oldie = newI;
                newI += list[newI];
                jumps++;
                list[oldie]++;
            }
            Console.WriteLine(jumps);
            Console.ReadKey();
        }
        public static void Part2()
        {
            var list = File.ReadAllLines("Day5/Day5.txt").Select(x => int.Parse(x)).ToArray();
            while (newI >= 0 && newI < list.Length)
            {
                jumps++;
                oldie = newI;
                newI += list[newI];
                list[oldie] += list[oldie] > 2 ? -1 : 1;
            }
            Console.WriteLine(jumps);
            Console.ReadKey();
        }
    }
}
