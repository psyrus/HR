using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/utopian-tree
    /// The Utopian Tree goes through 2 cycles of growth every year. Each spring, it doubles in height. Each summer, its height increases by 1 meter.
    /// Laura plants a Utopian Tree sapling with a height of 1 meter at the onset of spring.How tall will her tree be after growth cycles?
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int yearlyGrowthFactor = 2;
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double power = (n + n % 2) / 2 + 1;
            Console.WriteLine(Math.Pow(yearlyGrowthFactor, power) - (1 + n % 2)) ;
        }
    }
}
