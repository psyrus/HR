using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/taum-and-bday
    /// Taum is planning to celebrate the birthday of his friend, Diksha. There are two types of gifts that Diksha wants from Taum: one is black and the other is white. To make her happy, Taum has to buy B number of black gifts and W number of white gifts.
    /// -The cost of each black gift is X units.
    /// -The cost of every white gift is Y units.
    /// -The cost of converting each black gift into white gift or vice versa is Z units.
    /// Help Taum by deducing the minimum amount he needs to spend on Diksha's gifts.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_b = Console.ReadLine().Split(' ');
            long b = Convert.ToInt64(tokens_b[0]);
            long w = Convert.ToInt64(tokens_b[1]);
            string[] tokens_x = Console.ReadLine().Split(' ');
            long x = Convert.ToInt64(tokens_x[0]);
            long y = Convert.ToInt64(tokens_x[1]);
            long z = Convert.ToInt64(tokens_x[2]);

            if (z + x < y)
            {
                Console.WriteLine(x * (b+w) + (z * w));
                continue;
            }
            else if (z + y < x)
            {
                Console.WriteLine(y * (b + w) + (z * b));
                continue;
            }
            else
            {
                Console.WriteLine(x * b + y * w);
                continue;
            }
        }
    }
}
