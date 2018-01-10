using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class Day6
    {
        public static void Part1()
        {
            var input = getfile();
            var tmpList = new List<int[]>();
            var counter = 0;
            do
            {
                tmpList.Add(input.ToArray());
                var maxvalue = input.Max();
                var index = Array.IndexOf(input, maxvalue);

                input[index] = 0;
                for (var i = 1; i <= maxvalue; i++)
                {
                    index++;
                    if (index >= input.Count())
                    {
                        index = 0;
                    }
                    input[index]++;
                }
                counter++;
            }
            while (!tmpList.Any(x => x.SequenceEqual(input)));
            Console.WriteLine(tmpList.Count());
            Console.ReadLine();


        }

        private static int[] getfile()
        {
            return File.ReadAllLines("Day6/Day6.txt").First().Split('\t').Select(x => Int32.Parse(x)).ToArray();
        }

        public static void Part2()
        {
            var input = getfile();
            var tmpList = new List<int[]>();
            var counter = 0;
            do
            {
                tmpList.Add(input.ToArray());
                var maxvalue = input.Max();
                var index = Array.FindIndex(input, x => x == maxvalue);

                input[index] = 0;
                for (var i = 1; i <= maxvalue; i++)
                {
                    index++;
                    if (index >= input.Count())
                    {
                        index = 0;
                    }
                    input[index]++;
                }
                counter++;
            }
            while (!tmpList.Any(x => x.SequenceEqual(input)));
            var result = tmpList.Count - tmpList.FindIndex(x => x.SequenceEqual(input));
            Console.WriteLine(result);
            Console.ReadLine();


        }
    }
}
