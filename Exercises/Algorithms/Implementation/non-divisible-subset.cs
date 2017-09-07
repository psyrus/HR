using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/non-divisible-subset
    /// Given a set, S, of n distinct integers, print the size of a maximal subset, S', of S where the sum of any 2 numbers in S' is not evenly divisible by k.
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int[] firstLine = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int numItems = firstLine[0];
        int k = firstLine[1];

        int[] numberSet = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //Test each set
        for (int i = 0; i < numItems; i++)
        {
            int thisOne = numberSet[i];
            int[] validNumbers = new int[numItems];
            int index = 0;
            for (int j = 0; j < numItems; j++)
            {
                if ((numberSet[j] + thisOne) % k == 0)
                {
                    validNumbers[index] = numberSet[j];
                    index++;
                }
            }
            Console.WriteLine(String.Join(" ", validNumbers));
        }
    }
}