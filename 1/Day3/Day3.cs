using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
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
        public static void Part2()
        {
            var list = new List<int>{1,1};
            var value = 325489;
            var index = 2;
            var currentCorner = 2;
            var nextCorner = 2;
            var cornerIndex = 1;

            while (true)
            {
                list.Add(list[index - 1]);

                if (nextCorner == index)
                {
                    list[index] += list[index - (cornerIndex * 2)];
                    currentCorner = nextCorner;
                    cornerIndex++;
                    int nextCornerIndex = cornerIndex + 1;
                    nextCorner = (nextCornerIndex + nextCornerIndex % 2) * (nextCornerIndex + 2 - nextCornerIndex % 2) / 4;
                }
                else
                {
                    if (index == currentCorner + 1)
                    {
                        list[index] += list[index - 2];
                    }
                    else
                    {
                        list[index] += list[index - (cornerIndex * 2)];
                    }

                    list[index] += list[index - (cornerIndex * 2 - 1)];

                    if (index != nextCorner - 1)
                    {
                        list[index] += list[index - (cornerIndex * 2 - 2)];
                    }
                }

                if (list[index] > value)
                    break;
                index++;
            }

            Console.WriteLine(list[index]);
            Console.ReadLine();
        }
    }
}
