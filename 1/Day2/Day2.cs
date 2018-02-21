using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class Day2
    {

        public static int Day2dot1()
        {

            var result = File.ReadAllLines("Day2/day2.txt");

            var spiltArray = result.Select(x => x.Split()).ToArray();

            var t = spiltArray.Select(x => x.Select(int.Parse));

            var r = t.Select(y => y.Max() - y.Min()).ToArray();
            var l = 0;
            for (int i = 0; i < r.Length; i++)
            {
                l += r[i];
            }

            return l;

        }

        public static int Day2dot2()
        {
            var result = File.ReadAllLines("Day2/day2.txt");

            var spiltArray = result.Select(x => x.Split()).ToArray();

            var t = spiltArray.Select(x => x.Select(y => int.Parse(y)));

            var i = t.Select(arr => arr.Select(x => arr.Select(y => (x % y == 0 ? x / y : 0)).Max()).Max()).Sum();

            return i;

        }



    }
}
