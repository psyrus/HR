using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// Calvin is driving his favorite vehicle on the 101 freeway. He notices that the check engine light of his vehicle is on, and he wants to service it immediately to avoid any risks. Luckily, a service lane runs parallel to the highway. The length of the service lane is N units. The service lane consists of N segments of equal length and different width.
    /// 
    /// Calvin can enter to and exit from any segment.Let's call the entry segment as index i and the exit segment as index j. Assume that the exit segment lies after the entry segment (i lt j) and 0 lte i. Calvin has to pass through all segments from index  to index  (both inclusive).

    /// Calvin has three types of vehicles - bike, car, and truck - represented by 1, 2 and 3, respectively. These numbers also denote the width of the vehicle.
    /// You are given an array width of length N, where width[k] represents the width of the kth segment of the service lane.
    /// It is guaranteed that while servicing he can pass through at most 1000 segments, including the entry and exit segments.
    /// If width[k] = 1 , only the bike can pass through the kth segment.
    /// If width[k] = 2, the bike and the car can pass through the kth segment.
    /// If width[k] = 3, all three vehicles can pass through the kth segment.
    /// Given the entry and exit point of Calvin's vehicle in the service lane, output the type of the largest vehicle which can pass through the service lane (including the entry and exit segments).
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int t = Convert.ToInt32(tokens_n[1]);
        string[] width_temp = Console.ReadLine().Split(' ');
        int[] width = Array.ConvertAll(width_temp, Int32.Parse);
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_i = Console.ReadLine().Split(' ');
            int i = Convert.ToInt32(tokens_i[0]);
            int j = Convert.ToInt32(tokens_i[1]);

            int minWidth = 3;
            for (int k = i; k <= j; k++)
            {
                if (width[k] < minWidth)
                {
                    minWidth = width[k];
                }

                if (minWidth == 1)
                {
                    break;
                }
            }

            Console.WriteLine(minWidth);
        }
    }
}
