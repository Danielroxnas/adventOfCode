using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Day10
    {


        public const int LIST_LENGTH = 256;
        public static void PartOne()
        {
            var lengths = File.ReadAllText("Day10/Day10.txt").Split(',').Select(int.Parse).ToList();

            var list = Enumerable.Range(0, LIST_LENGTH).ToArray();
            var cur = 0;
            var skip = 0;

            foreach (var length in lengths)
            {
                list = TieKnot(list, cur, skip, length);
                cur += length + skip++;
                cur %= LIST_LENGTH;
            }

            var result = (list[0] * list[1]).ToString();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int[] TieKnot(int[] list, int cur, int skip, int length)
        {
            var subList = new int[length];

            for (var i = 0; i < length; i++)
            {
                subList[i] = list[(cur + i) % LIST_LENGTH];
            }

            subList = subList.Reverse().ToArray();

            for (var i = 0; i < length; i++)
            {
                list[(cur + i) % LIST_LENGTH] = subList[i];
            }

            return list;
        }



        public static void PartTwo()
        {
            var lengths = File.ReadAllText("Day10/Day10.txt").Select(x => (int)x);

            lengths = lengths.Concat(new int[] { 17, 31, 73, 47, 23 }).ToList();

            var list = Enumerable.Range(0, LIST_LENGTH).ToArray();
            var cur = 0;
            var skip = 0;

            for (var i = 0; i < 64; i++)
            {
                foreach (var length in lengths)
                {
                    list = TieKnot(list, cur, skip, length);
                    cur += length + skip++;
                    cur %= LIST_LENGTH;
                }
            }

            var denseHash = GetDenseHash(list);

            var result = string.Join(string.Empty, denseHash.Select(x => ConvertToHex(x)));

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static string ConvertToHex(int hash)
        {
            return hash.ToString("x2");
        }

        private static List<int> GetDenseHash(int[] list)
        {
            var denseHash = new List<int>();

            for (var x = 0; x < LIST_LENGTH; x += 16)
            {
                var hash = 0;

                for (int i = 0; i < 16; i++)
                {
                    hash ^= list[x + i];
                }

                denseHash.Add(hash);
            }

            return denseHash;
        }
    }
}
