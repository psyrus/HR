using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/the-hurdle-race
    /// Dan is playing a video game in which his character competes in a hurdle race by jumping over  hurdles with heights.
    /// He can initially jump a maximum height of  units, but he has an unlimited supply of magic beverages that help him jump higher!
    /// Each time Dan drinks a magic beverage, the maximum height he can jump during the race increases by  unit.
    /// Given n, k, and the heights of all the hurdles, find and print the minimum number of magic beverages Dan must drink to complete the race.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] height_temp = Console.ReadLine().Split(' ');
        int[] height = Array.ConvertAll(height_temp, Int32.Parse);
        // your code goes here

        int maxHeight = 0;
        foreach (var item in height)
        {
            if (item > maxHeight)
            {
                maxHeight = item;
            }
        }

        Console.WriteLine(maxHeight > k ? maxHeight - k : 0);
    }
}
