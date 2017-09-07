using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/equality-in-a-array
    /// Karl has an array of n integers defined as A = a0,a1, ... an. In one operation, he can delete any element from the array.
    /// Karl wants all the elements of the array to be equal to one another.To do this, he must delete zero or more elements from the array. Find and print the minimum number of deletion operations Karl must perform so that all the array's elements are equal.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numEntries = int.Parse(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int highestNumber = 100;
        int[] count = new int[highestNumber + 1];

        int maxCountIndex = 0;

        for (int i = 0; i < numEntries; i++)
        {
            count[numbers[i]]++;
            if (count[numbers[i]] > count[maxCountIndex])
            {
                maxCountIndex = numbers[i];
            }
        }

        Console.WriteLine(numEntries - count[maxCountIndex]);
    }
}