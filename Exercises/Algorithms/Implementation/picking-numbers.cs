using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    /// <summary>
    /// Given an array of integers, find and print the maximum number of integers you can select from the array such that the absolute difference between any two of the chosen integers is <=1.
    /// 1 < n < 100
    /// 0 < ai < 100
    /// Answer >= 2
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);


        //Load each number into a tracking array
        int[] tracker = new int[100];
        int maxVal = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] > maxVal)
            {
                maxVal = a[i];
            }

            tracker[a[i]]++;
        }

        //Keep track of "highest total"
        int highestTotal = 0;

        //Loop through tracking array, with i, i-1 and i+1 total
        for (int i = 1; i <= maxVal; i++)
        {
            int currentValCount = tracker[i];
            int prevValCount = tracker[i - 1];

            int thisTotal = currentValCount + prevValCount;

            if (thisTotal > highestTotal)
            {
                highestTotal = thisTotal;
            }
        }

        Console.WriteLine(highestTotal);
    }
}
