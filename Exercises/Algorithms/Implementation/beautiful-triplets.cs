using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/beautiful-triplets
    /// Erica wrote an increasing sequence of n numbers (a0...an-1) in her notebook. She considers a triplet (ai, aj, ak) to be beautiful if:
    /// ◎ i lt j lt k
    /// ◎ a[j] - a[i] = a[k] - a[j] = d
    /// Given the sequence and the value of d, can you help Erica count the number of beautiful triplets in the sequence?
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] firstLine = Console.ReadLine().Split(' ');
        int sequenceLength = int.Parse(firstLine[0]);
        int beautifulDiff = int.Parse(firstLine[1]);

        int[] sequence = new int[sequenceLength];

        int maxVal = 20000;
        int[] valTracker = new int[maxVal+1];
        int index = 0;
        foreach(var item in Console.ReadLine().Split(' '))
        {
            sequence[index] = int.Parse(item);
            valTracker[sequence[index]]++;

            index++;

        }

        int beauts = 0;
        for (int i = 0; i < sequenceLength; i++)
        {
            int ai = sequence[i];
            int aj = ai + beautifulDiff;
            int ak = ai + 2 * beautifulDiff;
            //Console.WriteLine($"Checking {sequence[i]} vs {sequence[i] + beautifulDiff} vs {sequence[i] + 2 * beautifulDiff}");
            if (ak <= maxVal && valTracker[aj] > 0 && valTracker[ak] > 0)
            {
                beauts++;
            }
        }

        Console.WriteLine(beauts);
    }
}