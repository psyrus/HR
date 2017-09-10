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

        if (k == 1 && numItems > 0)
        {
            Console.WriteLine("1");
        }

        int[] numberSet = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] remainderGroupings = new int[k];
        int longestSetIndex = 0;
        //Test each set
        for (int i = 0; i < numItems; i++)
        {
            int baseLine = numberSet[i];
            int remainderGroup = GetRemainderGroup(baseLine, k);

            remainderGroupings[remainderGroup]++;
        }

        int max = 0;
        //Work out which is the bigger of the two compliments of remaindergroupings subsets, and take that value. Add it to the total
        for (int i = 1; i <= remainderGroupings.Length/2; i++)
        {
            int thisOne = remainderGroupings[i] > remainderGroupings[k - i] ? remainderGroupings[i] : remainderGroupings[k - i];
            max += thisOne;
            Console.WriteLine($"{i}:{remainderGroupings[i]} vs {k-i}:{remainderGroupings[k-i]} => {thisOne}");
        }
        Console.WriteLine(max);
    }

    private static int GetRemainderGroup(int baseLine, int k)
    {
        return (int)(Math.Ceiling((double)baseLine / (double)k) * k - baseLine);
    }
}