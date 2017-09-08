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
        HashSet<int> alreadySeen = new HashSet<int>();
        int longestSetLength = 0;
        //Test each set
        for (int i = 0; i < numItems; i++)
        {
            int baseLine = numberSet[i];

            if (alreadySeen.Contains(baseLine))
            {
                continue;
            }

            int[] theseValid = new int[numberSet.Length];
            theseValid[0] = baseLine;
            int theseValidIndex = 1;
            foreach (var item in numberSet)
            {
                if (item != baseLine && isValidInGroup(item, theseValid, k))
                {
                    theseValid[theseValidIndex] = item;
                    theseValidIndex++;
                }
            }
            Console.WriteLine(baseLine + ": " + String.Join(" ", theseValid));
            alreadySeen.UnionWith(theseValid);

            if (theseValidIndex > longestSetLength)
            {
                longestSetLength = theseValidIndex;
            }
        }
        Console.WriteLine(longestSetLength);
    }

    private static bool isValidInGroup(int item, int[] theseValid, int divisor)
    {
        foreach (var validItem in theseValid)
        {
            if ((item + validItem) % divisor == 0)
            {
                return false;
            }
        }
        return true;
    }
}