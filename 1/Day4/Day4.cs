using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class Day4
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Day4/Day4.txt");
            var c = input.Select(x => x.Split(' '))
                .Count(x => x.Length == new HashSet<string>(x)
                .Count);
            Console.WriteLine(c);
            Console.ReadLine();
        }
        public static void Part2()
        {
            var input = File.ReadAllLines("Day4/Day4.txt");

            var c = input.Select(x => x.Split(' '))
                .Select(x => x.GroupBy(y => string.Concat(y.OrderBy(z => z)))
                .Any(z => z.Count() > 1) ? 0: 1).Sum();
            Console.WriteLine(c);
            Console.ReadLine();
        }

    }
}
