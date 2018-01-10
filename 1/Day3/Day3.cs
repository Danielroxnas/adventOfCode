using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Day3
{
    public static class Day3
    {
        public static void Part3()
        {

            int value = 325489;
            int index = 0;
            int count = 1;

            if (value != 1)
            {
                while (count * count < value)
                {
                    count += 2;
                    index++;
                }
                int result = Math.Abs(index - ((count * count - value) % (count - 1)));
                Console.WriteLine(result + index);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
