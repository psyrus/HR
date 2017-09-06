using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/cut-the-sticks
    /// You are given  sticks, where the length of each stick is a positive integer. A cut operation is performed on the sticks such that all of them are reduced by the length of the smallest stick.
    /// Suppose we have six sticks of the following lengths:
    /// 5 4 4 2 2 8
    /// Then, in one cut operation we make a cut of length 2 from each of the six sticks.For the next cut operation four sticks are left (of non-zero length), whose lengths are the following:
    /// 3 2 2 6
    /// The above step is repeated until no sticks are left.
    /// Given the length of sticks, print the number of sticks that are left before each subsequent cut operations.
    /// Note: For each cut operation, you have to recalcuate the length of smallest sticks (excluding zero-length sticks).
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        Array.Sort(arr);

        int totalElements = n;
        int totalCutLength = 0;
        int cutFromIndex = 0;

        while (cutFromIndex < totalElements)
        {
            int cutThisTime = totalElements - cutFromIndex;
            int minLength = arr[cutFromIndex];
            cutFromIndex++;
            while (cutFromIndex < totalElements && arr[cutFromIndex] == minLength)
            {
                cutFromIndex++;
            }

            Console.WriteLine(cutThisTime);
        }
    }
}
