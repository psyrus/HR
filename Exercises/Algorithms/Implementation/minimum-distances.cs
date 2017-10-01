using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/minimum-distances
    /// Consider an array of n integers, A=[a0...an]. The distance between two indices, i and j, is denoted by di,j = |i-j|.
    /// Given A, find the minimum di,j such that ai == aj and i!=j. 
    /// In other words, find the minimum distance between any pair of equal elements in the array. If no such value exists, print -1.
    /// Note: |a| denotes the absolute value of a.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] A_temp = Console.ReadLine().Split(' ');
        int[] A = Array.ConvertAll(A_temp, Int32.Parse);

        Dictionary<int, List<int>> numberIndexes = new Dictionary<int, List<int>>();
        int currentMinDistance = -1;
        for (int i = 0; i < n; i++)
        {
            int item = A[i];
            if (!numberIndexes.ContainsKey(item))
            {
                numberIndexes[item] = new List<int>();
            }

            numberIndexes[item].Add(i);

            if (numberIndexes[item].Count > 1)
            {
                int thisMinDistance = numberIndexes[item].Last() - numberIndexes[item][numberIndexes[item].Count - 2];
                if (currentMinDistance == -1 || thisMinDistance < currentMinDistance)
                {
                    currentMinDistance = thisMinDistance;
                }
            }
        }

        Console.WriteLine(currentMinDistance);
        Console.ReadLine();
    }
}
