using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static int[] acmTeam(string[] topic)
    {
        int maxKnown = 0;
        int maxKnowCount = 0;
        // Calculate all possible groupings, check if each grouping's total known is the max, 
        // if so increment the total number who know the max
        for (int i = 0; i < topic.Length - 1; i++)
        {
            for (int j = i + 1; j < topic.Length; j++)
            {
                int totalKnown = GetTotalKnown(topic[i], topic[j]);
                if (totalKnown > maxKnown)
                {
                    maxKnown = totalKnown;
                    maxKnowCount = 1;
                }
                else if (totalKnown == maxKnown)
                {
                    maxKnowCount++;
                }
            }
        }

        int[] returnstuff = { maxKnown, maxKnowCount };
        return returnstuff;
    }

    private static int GetTotalKnown(string v1, string v2)
    {
        int total = 0;
        for (int i = 0; i < (v1.Length + v2.Length) / 2; i++)
        {
            total += v1[i] == '1' || v2[i] == '1' ? 1 : 0;
        }
        return total;
    }

    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] topic = new string[n];
        for (int topic_i = 0; topic_i < n; topic_i++)
        {
            topic[topic_i] = Console.ReadLine();
        }
        int[] result = acmTeam(topic);
        Console.WriteLine(String.Join("\n", result));


    }
}
